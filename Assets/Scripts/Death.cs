using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool oneTime = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!oneTime && other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            
            damagable.TakeDamage(damage * Time.deltaTime);
        }
    }
}

public interface IDamagable
{
    public void TakeDamage(float damage);
}
