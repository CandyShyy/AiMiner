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
        if (other.CompareTag("mineralZone") && other.GetComponent<Collider2D>().IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()))
        {
            ACMining playerMining = GameObject.FindGameObjectWithTag("Player").GetComponent<ACMining>();

            // Add the player's mined minerals to the ACMinerals script
            Minerals += playerMining.totalMineralsHarvested;

            // Reset the player's mined minerals
            playerMining.totalMineralsHarvested = 0;

            mineralsText.text = Minerals.ToString();
        }
    }
}
