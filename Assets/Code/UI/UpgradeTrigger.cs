using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour
{
    public GameObject upgradeUI;
    public ACController acController;
    public ACMining acMining; 

    private Rigidbody2D acRigidbody;
    private Collider2D playerCollider;
    private bool canTriggerUpgrade = true;

    private void Start()
    {
        upgradeUI.SetActive(false);
        acRigidbody = acController.GetComponent<Rigidbody2D>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(); 
    }

    private IEnumerator CooldownCoroutine()
    {
        canTriggerUpgrade = false;
        yield return new WaitForSeconds(3f);
        canTriggerUpgrade = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is tagged as a MineralsZone and the player is in contact with it
    if (canTriggerUpgrade && other.CompareTag("mineralZone") && other.GetComponent<Collider2D>().IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()))
        {
            upgradeUI.SetActive(true);
            acController.enabled = false;
            acRigidbody.constraints = RigidbodyConstraints2D.FreezeAll; 
        }
    }

    public void OnExitShop()
    {
        // Hide the shop UI
        upgradeUI.SetActive(false);
        // Enable the ACController script
        acController.enabled = true;
        acRigidbody.constraints = RigidbodyConstraints2D.None;
        StartCoroutine(CooldownCoroutine());
    }
}

