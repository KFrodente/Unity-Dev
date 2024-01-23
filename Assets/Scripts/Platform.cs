using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Animator animator;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			animator.SetTrigger("Move");
		}
	}
}
