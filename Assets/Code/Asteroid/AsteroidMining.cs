using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMining : MonoBehaviour
{
    public int minMinerals = 2;
    public int maxMinerals = 10;

    public Sprite littleMinedSprite;
    public Sprite halfMinedSprite;
    public Sprite fullyMinedSprite;

    private int currentMinerals;
    private SpriteRenderer parentSpriteRenderer; // reference to the parent's sprite renderer

    private void Start()
    {
        maxMinerals = Random.Range(minMinerals, maxMinerals);
        currentMinerals = maxMinerals;

        parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>(); // get the parent's sprite renderer component
    }

    public int Mine(int amount) // modified to return the number of minerals mined
    {
        currentMinerals -= amount;
        if (currentMinerals <= 0)
        {
            // The asteroid is depleted, so you can destroy it and update the parent's sprite
            if (parentSpriteRenderer != null)
            {
                parentSpriteRenderer.sprite = fullyMinedSprite;
                Destroy(gameObject);
            }
        }
        else if (currentMinerals <= maxMinerals / 2)
        {
            // Half of the minerals are mined, change sprite
            parentSpriteRenderer.sprite = halfMinedSprite;
        }
        else if (currentMinerals <= maxMinerals -1)
        {
            // Little of the minerals are mined, change sprite
            parentSpriteRenderer.sprite = littleMinedSprite;
        }
            return amount; // return the number of minerals mined
    }
}


