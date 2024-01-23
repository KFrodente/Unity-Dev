using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField, Range(0, 10)] private float jumpForce;
    [SerializeField, Range(0, 10)] private float maxForce;
    [SerializeField] private Transform view;
    [Header("Collision")]
    [SerializeField, Range(0, 3)] private float rayLength = 1;
    [SerializeField] private LayerMask groundLayerMask;

    public Rigidbody rb;
    private Vector3 force;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        Quaternion yRotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);
        force = yRotation * direction * maxForce;
        rb.AddForce(force, ForceMode.Force);

        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.green);
        if (Input.GetButtonDown("Jump") && OnGround())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool OnGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void IncreaseJumpPower(float amount)
    {
        jumpForce += amount;
    }
}
