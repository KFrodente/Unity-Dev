using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField, Range(2, 15)] private float distance;

    [SerializeField] private float sensitivity;
    [SerializeField, Range(20, 90)] private float pitch = 40;
    private float yaw = 0;


    private Quaternion qPitch;
    private Quaternion qYaw;
    private Quaternion rotation;

    private void Start()
    {
        
    }

    private void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;

        qPitch = Quaternion.AngleAxis(pitch, Vector3.right);
        qYaw = Quaternion.AngleAxis(yaw, Vector3.up);
        rotation = qYaw * qPitch;


        transform.position = target.position + (rotation * Vector3.back * distance);
        transform.rotation = rotation;
    }
}
