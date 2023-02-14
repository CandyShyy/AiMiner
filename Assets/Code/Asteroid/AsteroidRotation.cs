using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    // The speed at which the object will rotate
    public float rotationSpeed = 50f;

    private void Start()
    {
        // Get a random value between 0 and 1
        float randomValue = Random.value;

        // If the random value is less than 0.5, rotate the object in the opposite direction
        if (randomValue < 0.5f)
        {
            rotationSpeed = -rotationSpeed;
        }
    }

    private void Update()
    {
        // Rotate the object by the specified amount each frame
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
