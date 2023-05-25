using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    public GameObject exclamationPointObject;

    [SerializeField]
    private float _playerAwarenessDistance;
    
    [SerializeField]
    private float _stopScriptsDistance;

    private Transform _player;
    private AIDestinationSetter aiDestinationSetter;
    private bool scriptsEnabled;

    private void Awake()
    {
        _player = FindObjectOfType<ACController>().transform;
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        scriptsEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        float distanceToPlayer = enemyToPlayerVector.magnitude;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (distanceToPlayer <= _playerAwarenessDistance && scriptsEnabled)
        {
            AwareOfPlayer = true;
            aiDestinationSetter.enabled = true;
            exclamationPointObject.SetActive(true);
        }
        else
        {
            AwareOfPlayer = false;
            aiDestinationSetter.enabled = false;
            exclamationPointObject.SetActive(false);
        }

        // Check if the player is far away and disable scripts if necessary
        if (distanceToPlayer > _stopScriptsDistance && scriptsEnabled)
        {
            DisableScripts();
        }
        else if (distanceToPlayer <= _stopScriptsDistance && !scriptsEnabled)
        {
            EnableScripts();
        }
    }

    private void DisableScripts()
    {
        // Disable any other scripts or functionality you want to stop
        scriptsEnabled = false;
        // Stop any movement or animations here
    }

    private void EnableScripts()
    {
        // Enable any other scripts or functionality you want to resume
        scriptsEnabled = true;
        // Resume movement or animations here
    }
}
