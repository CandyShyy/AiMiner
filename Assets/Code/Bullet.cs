using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    private bool hasCollided = false;

    public float destroyDelay = 180f; // Time in seconds before destruction

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
            hasCollided = true;
        }
    }
}

