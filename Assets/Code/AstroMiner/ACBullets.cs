using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACBullets : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    private bool hasCollided = false;

    public float destroyDelay = 5f; // Time in seconds before destruction

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasCollided)
        {
            return;
        }

        HealthController healthController = collision.GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.TakeDamage(damageAmount);
        }

        hasCollided = true;

        // Destroy the bullet object
        Destroy(gameObject);
    }

}

