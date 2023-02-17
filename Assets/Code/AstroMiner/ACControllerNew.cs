using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACControllerNew : MonoBehaviour
{
    public float maxSpeed = 10.0f; // The maximum speed the object can move
    public float backwardSpeed = 3.0f; // The speed at which the object moves backwards
    public float sprintSpeed = 15.0f; // The speed the object moves while sprinting
    public float acceleration = 5.0f; // The rate at which the object accelerates
    public float deceleration = 2.0f; // The rate at which the object decelerates
    public float steering = 2.0f; // The rate at which the object steer

    
    private Rigidbody2D rigidBody; // Reference to the Rigidbody2D component
    private Transform myTransform; // Reference to the Transform component
    private Animator animator; // Reference to the Animator component
    

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    private void Update()
{
    // Get mouse position in world space
    Vector3 mousePos = Input.mousePosition;
    mousePos = Camera.main.ScreenToWorldPoint(mousePos);

    // Calculate direction towards the mouse
    Vector2 direction = myTransform.InverseTransformPoint(mousePos);

    direction.Normalize(); // Normalize direction vector
}
}
