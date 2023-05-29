using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACDeath : MonoBehaviour
{
    public HealthController healthController;
    public GameObject DieScreen;

    [SerializeField]
    private float collisionThreshold = 10f;

    [Header("DeathDisable")]
    public ACMining miningScript;
    public ACController controllerScript;
    public ACShooting shootingScript;

    private Animator animator;
    private ACRespawn playerRespawner;

    void Start()
    {
        DieScreen.SetActive(false);
        animator = GetComponent<Animator>();
        playerRespawner = FindObjectOfType<ACRespawn>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Calculate the speed of the collision
        float speed = collision.relativeVelocity.magnitude;

        // Check if the collision speed is above the threshold
        if (speed > collisionThreshold)
        {
            // Calculate the amount of damage based on the collision speed
            float damage = speed / 0.5f;

            // Convert the damage to an integer
            int damageInt = Mathf.RoundToInt(damage);

            // Take the damage
            healthController.TakeDamage(damageInt);

            // Check if the health reaches zero
            if (healthController.currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        // Disable player scripts
        miningScript.enabled = false;
        controllerScript.enabled = false;
        shootingScript.enabled = false;

        // Show die screen and play death animation
        DieScreen.SetActive(true);
        animator.SetBool("isDead", true);

        // Trigger respawn
        playerRespawner.PlayerDied();
    }
}
