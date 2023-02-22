using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeTrigger : MonoBehaviour
{
    // References to game objects and components
    [Header("Upgrade UI")]
    public GameObject upgradeUI;
    [Header("AC")]
    public ACController acController;
    public ACMining acMining;
    public Rigidbody2D acRigidbody;
    public Collider2D playerCollider;
    [Header("Text")]
    public TextMeshProUGUI TextDescription;
    public TextMeshProUGUI TextStats;
    public TextMeshProUGUI TextCost;

    // Flag to prevent multiple upgrades from happening in quick succession
    private bool canTriggerUpgrade = true;

    // Initialize components and text values
    private void Start()
    {
        upgradeUI.SetActive(false); // hide the upgrade UI
        // assign references to components
        acRigidbody = acController.GetComponent<Rigidbody2D>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        // initialize text values
        TextDescription.text = "...";
        TextStats.text = "...";
        TextCost.text = "0";
    }

    // Coroutine to prevent multiple upgrades from happening in quick succession
    private IEnumerator CooldownCoroutine()
    {
        canTriggerUpgrade = false;
        yield return new WaitForSeconds(3f);
        canTriggerUpgrade = true;
    }

    // Called when player enters trigger collider on this game object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canTriggerUpgrade && playerCollider.gameObject.CompareTag("Player"))
        {
            // show the upgrade UI and disable AC controller
            upgradeUI.SetActive(true);
            acController.enabled = false;
            acRigidbody.constraints = RigidbodyConstraints2D.FreezeAll; 
        }
    }

    // Called when player exits the upgrade UI
    public void OnExitShop()
    {
        // hide the upgrade UI, enable AC controller, and set rigidbody constraints to none
        upgradeUI.SetActive(false);
        acController.enabled = true;
        acRigidbody.constraints = RigidbodyConstraints2D.None;
        // start cooldown coroutine to prevent multiple upgrades from happening in quick succession
        StartCoroutine(CooldownCoroutine());
    }

    // Upgrade methods to set text values in the UI
    public void Tier1()
    {
        TextDescription.text = "Mining upgrade level 1\nUpgraded with gremlinian ore.";
        TextStats.text = "- The speed of mineral extraction +1";
        TextCost.text = "10";
    }

    public void Tier2()
    {
        TextDescription.text = "Mining upgrade level 2\nUpgraded with gremlinian ore.";
        TextStats.text = "- The speed of mineral extraction +2";
        TextCost.text = "20";
    }

    public void Tier3()
    {
        TextDescription.text = "Mining upgrade level 3\nUpgraded with gremlinian ore.";
        TextStats.text = "- The speed of mineral extraction +3";
        TextCost.text = "30";
    }

    public void Tier4()
    {
        TextDescription.text = "Mining upgrade level 4\nUpgraded with gremlinian ore.";
        TextStats.text = "- The speed of mineral extraction +4";
        TextCost.text = "40";
    }

    public void Tier5()
    {
        TextDescription.text = "Mining upgrade level 5\nUpgraded with gremlinian ore.";
        TextStats.text = "- The speed of mineral extraction +5";
        TextCost.text = "50";
    }
}
