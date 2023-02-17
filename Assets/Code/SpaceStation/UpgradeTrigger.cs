using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour
{
    public GameObject upgradeUI;
    public ACController acController;
    public ACMining acMining;

    private Rigidbody2D acRigidbody;
    public Animator animator;


    public Sprite TREE36;

    public SpriteRenderer spriteRenderer;

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

    public void BuyUpgradeTier1()
    {
        acMining.mineralsPerSecond = 5;
        animator.SetBool("firstUpgrade", true);
        spriteRenderer.sprite = TREE36;
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

