using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACController : MonoBehaviour
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
    Vector2 direction = new Vector2(
        mousePos.x - myTransform.position.x,
        mousePos.y - myTransform.position.y
    );  

    direction.Normalize(); // Normalize direction vector

    

     // Add small sideways force when A or D is pressed
    if (Input.GetKey(KeyCode.A))
    {
        rigidBody.AddForce(-transform.right * steering);
    }
    else if (Input.GetKey(KeyCode.D))
    {
        rigidBody.AddForce(transform.right * steering);
    }


    // If 'S' key is pressed, move backwards
    if (Input.GetKey(KeyCode.S)) 
    {
        rigidBody.velocity -= direction * backwardSpeed * Time.deltaTime;

        if (rigidBody.velocity.magnitude > maxSpeed)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        }
        
        animator.SetBool("isMoving", true);
        animator.SetBool("isSprinting", false);
    }
    // If 'W' key is pressed, move forwards
    else if (Input.GetKey(KeyCode.W)) 
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rigidBody.velocity += direction * acceleration * Time.deltaTime * sprintSpeed / maxSpeed;

            if (rigidBody.velocity.magnitude > sprintSpeed)
            {
                rigidBody.velocity = rigidBody.velocity.normalized * sprintSpeed;
            }

            animator.SetBool("isMoving", true);
            animator.SetBool("isSprinting", true);
        }
        else
        {
            rigidBody.velocity += direction * acceleration * Time.deltaTime;

            if (rigidBody.velocity.magnitude > maxSpeed)
            {
                rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
            }

            animator.SetBool("isMoving", true);
            animator.SetBool("isSprinting", false);
        }
    }
    else
    {
        rigidBody.velocity -= rigidBody.velocity.normalized * deceleration * Time.deltaTime;

        if (rigidBody.velocity.magnitude < 0.1f)
        {
            rigidBody.velocity = Vector2.zero;
        }

        animator.SetBool("isMoving", false);
        animator.SetBool("isSprinting", false);
    }

    myTransform.up = direction;
    }
}