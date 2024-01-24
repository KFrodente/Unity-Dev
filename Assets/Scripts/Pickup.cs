using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	public ParticleSystem fire;


	public AudioSource source;
	public AudioClip bump;


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out Player player) && GetComponent<FollowPlayer>().state == FollowPlayer.State.IDLE)
		{
			GetComponent<FollowPlayer>().setState(FollowPlayer.State.FOLLOWING);
			GetComponent<FollowPlayer>().followTarget = player.gameObject;
        }
		if (GetComponent<FollowPlayer>().state != FollowPlayer.State.COLLECTED)
		{
			source.pitch = Random.Range(.8f, 1.3f);
			source.PlayOneShot(bump);
		}
	}
}
