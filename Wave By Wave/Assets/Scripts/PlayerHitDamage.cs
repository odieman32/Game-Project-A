using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDmage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Damage>(out Damage enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
    }
}
