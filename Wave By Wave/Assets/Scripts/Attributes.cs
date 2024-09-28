using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    [SerializeField] private float maxHealth; //field for max Health

    private float currentHealth; //float for current health

    public HealthBar healthBar; //public field to put health bar in

    public GameOver gameOverM; //used for the game over script

    private bool isDead; //bool to tell if dead 

    private void Start()
    {
        currentHealth = maxHealth; //current health is set to maxHealth

        healthBar.SetSLiderMax(maxHealth); //max health bar is set to max health
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount; //decreases amount if current health decreases
        healthBar.SetSlider(currentHealth); //sets the health bar acrodingly to current health
    }

    public void Update()
    {
        if (currentHealth <= 0 && !isDead) //if current health is less than or equal to 0 and the player is not dead then it will run the following
        {
            isDead = true; //is dead is set to true
            gameObject.SetActive(false); // the game object is set to false
            gameOverM.gameOver(); //game over m calls the game over function from Game Over script
            Debug.Log("Dead"); //dead is logged in the console
        }
    }
}
