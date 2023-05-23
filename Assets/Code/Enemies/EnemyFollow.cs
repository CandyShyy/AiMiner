using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            // Face the target
            Vector2 direction = target.position - transform.position;
            transform.up = direction;
        }
        else
        {
            // Attack code
        }
    }
}
