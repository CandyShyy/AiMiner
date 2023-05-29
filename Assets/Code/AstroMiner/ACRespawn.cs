using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACRespawn : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
    public float respawnTime = 5f;
    private GameObject playerInstance;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        playerInstance = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        // Add any additional initialization for the player here
    }

    private void RespawnPlayer()
    {
        Invoke("SpawnPlayer", respawnTime);
    }

    public void PlayerDied()
    {
        // Perform any necessary logic when the player dies
        RespawnPlayer();
    }
}