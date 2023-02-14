using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalMineralsStored : MonoBehaviour
{
    public int totalMinerals; // variable to store the total minerals stored at the space station
    public UnityEngine.UIElements.ProgressBar progressBar; // the ProgressBar component reference

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            ACMining playerMining = other.GetComponent<ACMining>();
            ACMining mineralsMined = other.GetComponent<ACMining>();

            // Store the player's mined minerals in the space station
            totalMinerals += playerMining.totalMineralsHarvested;

            // Reset the player's mined minerals
            playerMining.totalMineralsHarvested = 0;
        }
    }
}