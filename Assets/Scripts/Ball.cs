using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField, Range(0f, 20f)] private float force;

    [SerializeField] private Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * force, ForceMode.Impulse);
        }
    }
}
