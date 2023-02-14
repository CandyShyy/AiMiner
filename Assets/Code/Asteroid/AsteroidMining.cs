using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMining : MonoBehaviour
{
    public int minMinerals = 2;
    public int maxMinerals = 10;

    private int currentMinerals;

    private void Start()
    {
        maxMinerals = Random.Range(minMinerals, maxMinerals);
        currentMinerals = maxMinerals;
    }

    public int Mine(int amount) // modified to return the number of minerals mined
    {
        currentMinerals -= amount;
        if (currentMinerals <= 0)
        {
            // The asteroid is depleted, so you can destroy it and its parent
        Transform parentTransform = transform.parent;
        Destroy(gameObject);
        if (parentTransform != null)
        {
            Destroy(parentTransform.gameObject);
        }
    }
        return amount; // return the number of minerals mined
    }
}
