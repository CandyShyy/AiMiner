using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public ACController acController; // Reference to the ACController script
    public ACMining acMining; // Reference to the ACMining script
    public GameObject inventoryMenu; // Reference to the InventoryMenu game object

    private bool isInventoryMenuEnabled = false; // Set the initial value to false

    private void Start()
    {
        inventoryMenu.SetActive(isInventoryMenuEnabled);
        SetACState(!isInventoryMenuEnabled); // Set initial AC states
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInventoryMenuEnabled = !isInventoryMenuEnabled;
            inventoryMenu.SetActive(isInventoryMenuEnabled);
            SetACState(!isInventoryMenuEnabled); // Enable/disable ACs based on the inventory state

            if (isInventoryMenuEnabled)
            {
                Debug.Log("InventoryMenu enabled.");
            }
            else
            {
                Debug.Log("InventoryMenu disabled.");
            }
        }
    }

    private void SetACState(bool isEnabled)
    {
        acController.enabled = isEnabled;
        acMining.enabled = isEnabled;
    }
}
