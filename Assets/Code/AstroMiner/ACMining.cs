using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACMining : MonoBehaviour
{
    public Animator animator;

    public float miningRange = 2f; // Range of the mining zone
    public int mineralsPerSecond = 1; // Number of minerals harvested per second
    public int totalMineralsHarvested; // Total number of minerals harvested
    public int maxCargo = 100; // Maximum amount of minerals that can be harvested
    public ACMinerals acMineralsScript;

    private float timeSinceLastMine; // Time elapsed since the last mine

        private void Update()
    {
        // Increment the time elapsed since the last mine
        timeSinceLastMine += Time.deltaTime;

        // Get the mining zone object
        GameObject miningZone = transform.Find("Mining zone").gameObject;

        // Get the collider component from the mining zone object
        Collider2D miningZoneCollider = miningZone.GetComponent<Collider2D>();

        // Flag indicating whether or not the player is currently mining
        bool isMining = false;

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
                // Set the flag indicating that the player is mining
                isMining = true;

                // Mine minerals from the asteroid if enough time has passed and maxCargo is not reached
                if (timeSinceLastMine >= 1f && totalMineralsHarvested < maxCargo)
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
        animator.SetBool("IsMining", isMining);
    }
}
