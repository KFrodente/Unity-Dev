using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFollowing : MonoBehaviour
{
    public VoidEvent CollectPigeon;
    public AudioClip crying;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FollowPlayer follow) && !follow.collected && other.TryGetComponent(out Pickup pickup))
        {
            follow.setState(FollowPlayer.State.COLLECTED);
            Instantiate(pickup.fire, pickup.transform.position, transform.rotation);
            CollectPigeon.RaiseEvent();
            AudioController.Instance.PlayClipRandomPitch(crying);
        }
    }
}
