using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public enum State
    {
        SPAWN, IDLE, FOLLOWING, COLLECTED
    }

    private Transform spawnPos;

    public State state { get; private set; } = State.SPAWN;

    public GameObject followTarget;
    public bool collected;

    [SerializeField] private float minFollowDistance;
    [SerializeField] private float speed;
    [SerializeField] private Rotator rotator;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPos = transform;
    }

    private void Update()
    {
        switch (state)
        {
            case State.SPAWN:
                transform.position = new Vector3(spawnPos.position.x, spawnPos.position.y, spawnPos.position.z);
                rb.velocity = Vector3.zero;
                collected = false;
                state = State.IDLE;
                //Debug.Log(spawnPos.transform.position + name);
                break;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Death killZone) && !collected)
        {
            collected = true;
            Goal.Instance.onCollectPigeon();
            Destroy(gameObject);
        }
    }
}
