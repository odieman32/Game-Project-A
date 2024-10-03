using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage; //Float for damage

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If game object "player" hits the collision box, the game object takes damage
        if (collision.gameObject.TryGetComponent<Attributes>(out Attributes damageComponent))
        {
            damageComponent.TakeDamage(4);
        }
    }

}
