using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ACMining : MonoBehaviour
{
    [Header("MiningStats")]
    public float miningRange = 2f; // Range of the mining zone
    public int mineralsPerSecond = 1; // Number of minerals harvested per second
    public int maxCargo = 100; // Maximum amount of minerals that can be harvested
    public int totalMineralsHarvested; // Total number of minerals harvested

    [Header("Other")]
    public Animator animator;
    public TextMeshProUGUI mineralsText;

    private float timeSinceLastMine; // Time elapsed since the last mine

    private void Update()
    {
        // Check if the left mouse button is being held down
        bool isMouseButtonDown = Input.GetMouseButton(0);

        // Increment the time elapsed since the last mine
        timeSinceLastMine += Time.deltaTime;

        // Get the mining zone object
        GameObject miningZone = transform.Find("Mining zone").gameObject;

        // Get the collider component from the mining zone object
        Collider2D miningZoneCollider = miningZone.GetComponent<Collider2D>();

        // Get all colliders that are touching the mining zone collider
        ContactFilter2D contactFilter = new ContactFilter2D();
        Collider2D[] hitColliders = new Collider2D[10];
        int colliderCount = miningZoneCollider.OverlapCollider(contactFilter, hitColliders);

        // Iterate through the colliders that are touching the mining zone
        for (int i = 0; i < colliderCount; i++)
        {
            Collider2D collider = hitColliders[i];

            // Check if the collider is an asteroid
            if (collider.CompareTag("Minerals"))
            {
                // Mine minerals from the asteroid if enough time has passed and maxCargo is not reached
                if (timeSinceLastMine >= 1f && totalMineralsHarvested < maxCargo && isMouseButtonDown)
                {
                    int mineralsMined = collider.GetComponent<AsteroidMining>().Mine(mineralsPerSecond);
                    int remainingCargo = maxCargo - totalMineralsHarvested;
                    if (mineralsMined > remainingCargo)
                    {
                        mineralsMined = remainingCargo;
                    }
                    totalMineralsHarvested += mineralsMined; // update the total minerals harvested
                    timeSinceLastMine = 0f;
                }
            }
        }

        // Update the animator based on whether or not the player is mining
        animator.SetBool("IsMining", isMouseButtonDown);
        mineralsText.text = totalMineralsHarvested.ToString();
    }
}

public class ACMinerals : MonoBehaviour
{
    public int Minerals;

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
}
