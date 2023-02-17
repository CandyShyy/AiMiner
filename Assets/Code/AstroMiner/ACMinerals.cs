using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACMinerals : MonoBehaviour
{
    [Header("All Minerals")]
    public int Minerals;

    private string playerTag = "Player";
    private string mineralZone = "mineralZone";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is tagged as a MineralsZone and the player is in contact with it
        if (other.CompareTag(mineralZone) && other.GetComponent<Collider2D>().IsTouching(GameObject.FindGameObjectWithTag(playerTag).GetComponent<Collider2D>()))
        {
            ACMining playerMining = GameObject.FindGameObjectWithTag(playerTag).GetComponent<ACMining>();

            // Add the player's mined minerals to the ACMinerals script
            Minerals += playerMining.totalMineralsHarvested;

            // Reset the player's mined minerals
            playerMining.totalMineralsHarvested = 0;
        }
    }
}
