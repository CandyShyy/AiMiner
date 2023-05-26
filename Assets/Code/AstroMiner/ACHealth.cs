using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACHealth : MonoBehaviour
{
    [Header("Scripts")]
    public HealthController healthController;
    public HealthBar healthBar;

    [Header("GameObjects")]
    public GameObject DieScreen;

    [SerializeField]
    private float collisionThreshold = 10f;

    void Start()
    {
        //healthBar.SetMaxHealth(healthController.maximumHealth);
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
            float damage = speed / 2f;

            // Take the damage
            healthController.TakeDamage(damage);
        }
    }

    void Die()
    {
        DieScreen.SetActive(true);
        // Disable any other functionality specific to ACHealth
    }
}
