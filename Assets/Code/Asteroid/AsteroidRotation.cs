using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    // The initial random rotation of the asteroid
    private Quaternion initialRotation;

    private void Start()
    {
        // Generate a random rotation for the asteroid
        initialRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        transform.rotation = initialRotation;
    }

    private void Update()
    {
        // The asteroid remains fixed in its initial rotation, no additional rotation needed
    }
}
