using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPower : MonoBehaviour
{
    [SerializeField] private FloatEvent jumpPowerEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jumpPowerEvent.RaiseEvent(1.5f);
            Destroy(gameObject);
        }
    }
}
