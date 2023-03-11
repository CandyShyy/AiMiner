using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACRestoreHealth : MonoBehaviour
{
   public ACHealth acHealth;
   public HealthBar healthBar;
   
   void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.CompareTag("mineralZone"))
        {
            acHealth.currentHealth = acHealth.maxHealth;
            healthBar.SetHealth(acHealth.currentHealth);

            
        }
    }
}
