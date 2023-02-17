using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour
{
    public GameObject upgradeUI;
    public ACController acController;
    private Rigidbody2D acRigidbody;

    private void Start()
    {
        upgradeUI.SetActive(false);
        acRigidbody = acController.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the shop UI
            upgradeUI.SetActive(true);
            // Disable the ACController script
            acController.enabled = false;
            // Freeze the ACController rigidbody
            acRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void OnExitShop()
    {
        // Hide the shop UI
        upgradeUI.SetActive(false);
        // Enable the ACController script
        acController.enabled = true;
        // Unfreeze the ACController rigidbody
        acRigidbody.constraints = RigidbodyConstraints2D.None;
    }
}

