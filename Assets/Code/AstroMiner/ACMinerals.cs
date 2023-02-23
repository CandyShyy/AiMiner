using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ACMinerals : MonoBehaviour
{
    public int Minerals;

    public TextMeshProUGUI mineralsText;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is tagged as a MineralsZone and the player is in contact with it
        if (other.CompareTag("mineralZone"))
        {
            ACMining playerMining = GameObject.FindGameObjectWithTag("Player").GetComponent<ACMining>();

            // Add the player's mined minerals to the ACMinerals script
            Minerals += playerMining.totalMineralsHarvested;

            // Reset the player's mined minerals
            playerMining.totalMineralsHarvested = 0;
        }
    }

    private void Update() 
    {
        mineralsText.text = Minerals.ToString();
    }
}
