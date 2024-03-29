using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WanderingAI : MonoBehaviour
   {
    public float radius = 20;

    public IAstarAI ai;

    void Start () 
    {
        ai = (IAstarAI)GetComponent<AIPath>();
    }

    Vector3 PickRandomPoint () 
    {
        var point = Random.insideUnitSphere * radius;

        point.y = 0;
        point += ai.position;
        Debug.Log(point);
        return point;
    }

    void Update () 
    {
        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath)) {
            ai.destination = PickRandomPoint();
            ai.SearchPath();
        }
    }
    }
