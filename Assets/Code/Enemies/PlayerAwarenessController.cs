using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;
    private AIDestinationSetter aiDestinationSetter;

    private void Awake()
    {
        _player = FindObjectOfType<ACController>().transform;
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
            aiDestinationSetter.enabled = true;
        }
        else
        {
            AwareOfPlayer = false;
            aiDestinationSetter.enabled = false;
        }
    }
}
