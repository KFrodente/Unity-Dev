using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public bool randomAngle;
    [SerializeField, Range(-360f, 360f)] private float angle;

    public float speed;
    private void Start()
    {
        if (randomAngle) { angle = Random.Range(-15, 15); }
    }

    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(angle * Time.deltaTime, Vector3.up);
        //if (Input.GetKey(KeyCode.LeftShift))
        //    transform.position += transform.forward * speed * Time.deltaTime;
    }
}
