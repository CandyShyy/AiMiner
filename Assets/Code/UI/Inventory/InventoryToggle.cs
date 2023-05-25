using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public ACController acController; // Reference to the ACController script

    public GameObject inventoryMenu; // Reference to the InventoryMenu game object

    private bool isInventoryMenuEnabled = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInventoryMenuEnabled = !isInventoryMenuEnabled;
            inventoryMenu.SetActive(isInventoryMenuEnabled);

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
}
