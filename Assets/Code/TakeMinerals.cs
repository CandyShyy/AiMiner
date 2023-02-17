using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMinerals : MonoBehaviour
{
    public int totalMinerals; // variable to store the total minerals stored at the space station
    public UnityEngine.UIElements.ProgressBar progressBar; // the ProgressBar component reference

    public ACMinerals acMineralsScript; // reference to the ACMinerals script

    public Collider2D colliderToTrigger; // reference to the collider that should trigger the mineral collection

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the colliderToTrigger
        if (other == colliderToTrigger)
        {
            ACMining playerMining = other.GetComponent<ACMining>();

            // Add the player's mined minerals to the ACMinerals script
            acMineralsScript.Minerals += playerMining.totalMineralsHarvested;

            // Reset the player's mined minerals
            playerMining.totalMineralsHarvested = 0;
        }
    }
}
