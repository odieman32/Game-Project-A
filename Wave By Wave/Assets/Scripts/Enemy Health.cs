using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] EnemyHealthBar healthBar;


    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthBar>(); //gets the health bar component
    }
    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; //subtracts health by damage amount
        healthBar.UpdateHealthBar(health, maxHealth); //calls the health bar to update it

        //if health is less than or equal to 0 the enemy is destroyed
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
