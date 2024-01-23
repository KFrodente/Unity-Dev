using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFollowing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FollowPlayer follow))
        {
            follow.setState(FollowPlayer.State.COLLECTED);
        }
    }
}
