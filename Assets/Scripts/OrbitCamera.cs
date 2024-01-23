using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField, Range(2, 15)] private float distance;

    [SerializeField] private float sensitivity;
    [SerializeField, Range(20, 90)] private float defaultPitch = 40;
    private float defaultYaw = 0;


	private float pitch;
	private float yaw;

	private Quaternion qPitch;
    private Quaternion qYaw;
    private Quaternion rotation;

    private void Start()
    {
        pitch = defaultPitch;
        yaw = defaultYaw;
    }

    private void Update()
    {
        if (GameManager.Instance.state == GameManager.State.TITLE) return;

        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch += -Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -20, 80);

        qPitch = Quaternion.AngleAxis(pitch, Vector3.right);
        qYaw = Quaternion.AngleAxis(yaw, Vector3.up);
        rotation = qYaw * qPitch;


        transform.position = target.position + (rotation * Vector3.back * distance);
        transform.rotation = rotation;
    }
}
