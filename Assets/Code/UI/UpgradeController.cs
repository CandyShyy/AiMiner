using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeController : MonoBehaviour
{
    [Header("Tier costs:")]
    public int tier1Cost = 10;
    public int tier2Cost = 20;
    public int tier3Cost = 30;
    public int tier4Cost = 40;
    public int tier5Cost = 50;

    [Header("Upgrade texts:")]
    public TextMeshProUGUI upgradeDescriptionText;
    public TextMeshProUGUI upgradeStatsText;
    public TextMeshProUGUI costText;

    [Header("Tier buttons:")]
    public Toggle tier1Button;
    public Toggle tier2Button;
    public Toggle tier3Button;
    public Toggle tier4Button;
    public Toggle tier5Button;
    public Button buyButton;

    public Toggle[] upgradeToggles;
    private Toggle currentlySelectedToggle;

    private int currentTier = 0;
    private int currentCost = 0;

    private ACMinerals acMinerals;

    private bool upgradePurchased = false;

    void Start()
    {
        acMinerals = GameObject.FindObjectOfType<ACMinerals>(); // find ACMinerals script in scene

        // set initial upgrade and cost to tier 1
        currentTier = 1;
        currentCost = tier1Cost;
        upgradeDescriptionText.SetText("Upgrade Tier 1");
        upgradeStatsText.SetText(currentCost.ToString());
        costText.SetText(currentCost.ToString());

        // add listener for buy button
        buyButton.onClick.AddListener(BuyUpgrade);

        // Get all the upgrade toggles
        upgradeToggles = GetComponentsInChildren<Toggle>();

        // Add onValueChanged listener to each upgrade toggle
        foreach (Toggle upgradeToggle in upgradeToggles) {
            upgradeToggle.onValueChanged.AddListener(delegate { OnUpgradeToggle(upgradeToggle); });
        }
    }

    void OnEnable() 
    {
        foreach (Toggle toggle in upgradeToggles) {
            toggle.onValueChanged.AddListener(OnToggleSelected);
        }
    }

    void OnDisable() {
        foreach (Toggle toggle in upgradeToggles) {
            toggle.onValueChanged.RemoveListener(OnToggleSelected);
        }
    }

    void OnToggleSelected(bool isOn) {
        if (isOn) {
            if (currentlySelectedToggle != null && currentlySelectedToggle != Toggle.current) {
                currentlySelectedToggle.isOn = false;
            }
            currentlySelectedToggle = Toggle.current;
        }
    }

    void Update() {
        // check which tier button is selected
        if (tier1Button.isOn)
        {
            currentTier = 1;
            currentCost = tier1Cost;
            upgradeDescriptionText.SetText("Upgrade Tier 1");
            upgradeStatsText.SetText(currentCost.ToString());
        }
        else if (tier2Button.isOn)
        {
            currentTier = 2;
            currentCost = tier2Cost;
            upgradeDescriptionText.SetText("Upgrade Tier 2");
            upgradeStatsText.SetText(currentCost.ToString());
        }
        else if (tier3Button.isOn)
        {
            currentTier = 3;
            currentCost = tier3Cost;
            upgradeDescriptionText.SetText("Upgrade Tier 3");
            upgradeStatsText.SetText(currentCost.ToString());
        }
        else if (tier4Button.isOn)
        {
            currentTier = 4;
            currentCost = tier4Cost;
            upgradeDescriptionText.SetText("Upgrade Tier 4");
            upgradeStatsText.SetText(currentCost.ToString());
        }
        else if (tier5Button.isOn)
        {
            currentTier = 5;
            currentCost = tier5Cost;
            upgradeDescriptionText.SetText("Upgrade Tier 5");
            upgradeStatsText.SetText(currentCost.ToString());
        }

        // Enable buy button only if upgrade is not already purchased and player has enough minerals
    int playerMinerals = acMinerals.Minerals;
    if (!upgradePurchased && playerMinerals >= currentCost)
    {
        buyButton.interactable = true;
    }
    else
    {
        buyButton.interactable = false;
    }
    }

        void BuyUpgrade()
    {
        if (upgradePurchased)
        {
            Debug.Log("Upgrade already purchased.");
            return;
        }

        int playerMinerals = acMinerals.Minerals;

        if (playerMinerals < currentCost)
        {
            Debug.Log("Not enough minerals.");
            return;
        }

        // subtract cost from player's minerals
        acMinerals.Minerals -= currentCost;

        // set upgrade as purchased and update button text
        upgradePurchased = true;
        buyButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Purchased");

        // TODO: apply the upgrade based on the selected tier

        Debug.Log("Upgrade bought.");
    }
    
    public void OnUpgradeToggle(Toggle toggle) {
    // Uncheck all upgrade toggles except the one that was just toggled
    foreach (Toggle upgradeToggle in upgradeToggles) {
        if (upgradeToggle != toggle) {
            upgradeToggle.isOn = false;
        }
    }
}

}
