using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeTrigger : MonoBehaviour
{
    [Header("upgradeUI")]
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

    private bool canTriggerUpgrade = true;

    private void Start()
    {
        upgradeUI.SetActive(false);
        acRigidbody = acController.GetComponent<Rigidbody2D>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();

        TextDescription.text = "...";
        TextStats.text = "...";
        TextCost.text = "0";
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


    //Tiers
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

