using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickUp : MonoBehaviour
{
    public ParticleSystem explosion;

    public AudioClip pickupSound;
    public float timeToRemove;

    public FloatEvent fEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fEvent.RaiseEvent(timeToRemove);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
