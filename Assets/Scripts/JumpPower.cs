using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPower : MonoBehaviour
{
    [SerializeField] private FloatEvent jumpPowerEvent;

    public AudioClip collectedClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jumpPowerEvent.RaiseEvent(1.5f);
            AudioController.Instance.PlayClip(collectedClip);
            Destroy(gameObject);
        }
    }
}
