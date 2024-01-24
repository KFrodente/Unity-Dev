using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPlayer : MonoBehaviour
{

    public float launchForce;
    public FloatEvent launchPlayerEvent;
    public AudioClip launchSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            launchPlayerEvent.RaiseEvent(launchForce);
            AudioController.Instance.PlayClip(launchSound);
        }
    }
}
