using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 10;
    public int currentHealth;
    public float collisionThreshold = 10f;

    [Header("Scripts")]
    public ACController acController;
    public ACMining acMining;
    public HealthBar healthBar;

    [Header("GameObjects")]
    public GameObject DieScreen;
   
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        DieScreen.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Calculate the speed of the collision
        float speed = collision.relativeVelocity.magnitude;

        // Check if the collision speed is above the threshold
        if (speed > collisionThreshold)
        {
            // Calculate the amount of damage based on the collision speed
            int damage = Mathf.RoundToInt(speed / 2f);

            // Take the damage
            TakeDamage(damage);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        DieScreen.SetActive(true);
        acController.enabled = false; 
        acMining.enabled = false; 
    }
}
