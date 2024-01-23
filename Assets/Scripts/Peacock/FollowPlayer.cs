using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public enum State
    {
        IDLE, FOLLOWING, COLLECTED
    }

    public State state { get; private set; }

    public GameObject followTarget;
    private bool collected;

    [SerializeField] private float minFollowDistance;
    [SerializeField] private float speed;
    [SerializeField] private Rotator rotator;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        switch (state)
        {
            case State.IDLE:
                rotator.speed = 5;
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
                break;
            case State.FOLLOWING:
                rotator.speed = 0;
                if (Vector3.Distance(transform.position, followTarget.transform.position) > minFollowDistance)
                    rb.AddForce((followTarget.transform.position - transform.position).normalized * speed, ForceMode.Force);
                break;
            case State.COLLECTED:
                rotator.speed = 5;
                if (!collected)
                {
                    rb.velocity = Vector3.zero;
                    collected = true;
                }
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
                break;
        }
    }

    public void setState(State state)
    {
        this.state = state;
    }
}
