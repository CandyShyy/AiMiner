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
    public ACMinerals acMinerals;
    public Rigidbody2D acRigidbody;
    public Collider2D playerCollider;

    [Header("Text")]
    public TextMeshProUGUI TextDescription;
    public TextMeshProUGUI TextStats;
    public TextMeshProUGUI TextCost;

    //Upgrade costs
    private int upgradeCostT1 = 10;
    private int upgradeCostT2 = 20;
    private int upgradeCostT3 = 30;
    private int upgradeCostT4 = 40;
    private int upgradeCostT5 = 50;

    private bool upgradeT1Bought = false;
    private bool upgradeT2Unlocked = false;
    private bool upgradeT2Bought = false;
    private bool upgradeT3Unlocked = false;
    private bool upgradeT3Bought = false;
    private bool upgradeT4Unlocked = false;
    private bool upgradeT4Bought = false;
    private bool upgradeT5Unlocked = false;
    private bool upgradeT5Bought = false;

    // Flag to prevent multiple upgrades from happening in quick succession
    private bool canTriggerUpgrade = true;
    private int selectedTier = 0;
    private int upgradeCost = 0;

    // Initialize components and text values
    private void Start()
    {
        upgradeUI.SetActive(false); // hide the upgrade UI
        // assign references to components
        acRigidbody = acController.GetComponent<Rigidbody2D>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        acMinerals = FindObjectOfType<ACMinerals>();
        acMining = FindObjectOfType<ACMining>();
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
    public void Exit()
    {
        // hide the upgrade UI, enable AC controller, and set rigidbody constraints to none
        upgradeUI.SetActive(false);
        acController.enabled = true;
        acRigidbody.constraints = RigidbodyConstraints2D.None;
        // start cooldown coroutine to prevent multiple upgrades from happening in quick succession
        StartCoroutine(CooldownCoroutine());
    }

   public void Buy()
    {
    switch(selectedTier)
        {
        case 1:
            if (upgradeT1Bought)
            {
                TextDescription.text = "You have already bought this upgrade.";
                TextStats.text = "";
                return;
            }
            upgradeCost = upgradeCostT1;
            upgradeT1Bought = true;
            upgradeT2Unlocked = true;
            acMining.mineralsPerSecond = 2;
            break;
        case 2:
            if (!upgradeT2Unlocked)
            {
                TextDescription.text = "You must buy the previous upgrade first.";
                TextStats.text = "";
                return;
            }
            if (upgradeT2Bought)
            {
                TextDescription.text = "You have already bought this upgrade.";
                TextStats.text = "";
                return;
            }
            upgradeCost = upgradeCostT2;
            upgradeT2Bought = true;
            upgradeT3Unlocked = true;
            acMining.mineralsPerSecond = 3;
            break;
        case 3:
            if (!upgradeT3Unlocked)
            {
                TextDescription.text = "You must buy the previous upgrade first.";
                TextStats.text = "";
                return;
            }
            if (upgradeT3Bought)
            {
                TextDescription.text = "You have already bought this upgrade.";
                TextStats.text = "";
                return;
            }
            upgradeCost = upgradeCostT3;
            upgradeT3Bought = true;
            upgradeT4Unlocked = true;
            acMining.mineralsPerSecond = 4;
            break;
        case 4:
            if (!upgradeT4Unlocked)
            {
                TextDescription.text = "You must buy the previous upgrade first.";
                TextStats.text = "";
                return;
            }
            if (upgradeT4Bought)
            {
                TextDescription.text = "You have already bought this upgrade.";
                TextStats.text = "";
                return;
            }
            upgradeCost = upgradeCostT4;
            upgradeT4Bought = true;
            upgradeT5Unlocked = true;
            acMining.mineralsPerSecond = 5;
            break;
        case 5:
            if (!upgradeT5Unlocked)
            {
                TextDescription.text = "You must buy the previous upgrade first.";
                TextStats.text = "";
                return;
            }
            if (upgradeT5Bought)
            {
                TextDescription.text = "You have already bought this upgrade.";
                TextStats.text = "";
                return;
            }
            upgradeCost = upgradeCostT5;
            upgradeT5Bought = true;
            acMining.mineralsPerSecond = 6;
            break;
        default:
            TextDescription.text = "You have to select upgrade first!";
            TextStats.text = "";
            return;
        }

        if(acMinerals.Minerals < upgradeCost)
        {
            TextDescription.text = "You don't have enough minerals to buy this upgrade.";
            TextStats.text = "";
            return;
        }

    acMinerals.Minerals -= upgradeCost;
    }

    // Upgrade methods to set text values in the UI
    public void Tier1()
    {
        TextDescription.text = "Mining upgrade level 1\nUpgraded with gremlinian ore.";
        TextStats.text = "- The speed of mineral extraction +1";
        TextCost.text = upgradeCostT1.ToString();
        selectedTier = 1;
    }

    public void Tier2()
    {
        TextDescription.text = "Mining upgrade level 2\nUpgraded with gremlinian ore.";
        TextStats.text = "- The speed of mineral extraction +2";
        TextCost.text = upgradeCostT2.ToString();
        selectedTier = 2;
    }

    public void Tier3()
    {
        TextDescription.text = "Mining upgrade level 3\nUpgraded with gremlinian ore.";
        TextStats.text = "- The speed of mineral extraction +3";
        TextCost.text = upgradeCostT3.ToString();
        selectedTier = 3;
    }

    public void Tier4()
    {
        TextDescription.text = "Mining upgrade level 4\nUpgraded with gremlinian ore.";
        TextStats.text = "- The speed of mineral extraction +4";
        TextCost.text = upgradeCostT4.ToString();
        selectedTier = 4;
    }

    public void Tier5()
    {
        TextDescription.text = "Mining upgrade level 5\nUpgraded with gremlinian ore.";
        TextStats.text = "- The speed of mineral extraction +5";
        TextCost.text = upgradeCostT5.ToString();
        selectedTier = 5;
    }
}
