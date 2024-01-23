using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	public ParticleSystem explosion;

	public AudioClip[] clips;



	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out Player player) && GetComponent<FollowPlayer>().state == FollowPlayer.State.IDLE)
		{
			GetComponent<FollowPlayer>().setState(FollowPlayer.State.FOLLOWING);
			GetComponent<FollowPlayer>().followTarget = player.gameObject;

        }
	}
}
