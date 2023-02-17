using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACControllerEQRotate : MonoBehaviour
{
   /*
    public float maxSpeed = 10.0f; // The maximum speed the object can move
    public float backwardSpeed = 3.0f; // The speed at which the object moves backwards
    public float sprintSpeed = 15.0f; // The speed the object moves while sprinting
    public float acceleration = 5.0f; // The rate at which the object accelerates
    public float deceleration = 2.0f; // The rate at which the object decelerates
    public float steering = 2.0f; 
    public float rotationSpeed = 180.0f; // The rate at which the object rotates
    

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
            // Rotate the ship using Q and E
        if (Input.GetKey(KeyCode.Q))
        {
            myTransform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            myTransform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }

            // Add small sideways force when A or D is pressed
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(-transform.right * steering);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(transform.right * steering);
        }



        // Move the ship forwards or backwards
        float moveInput = Input.GetAxis("Vertical");
        if (moveInput < 0)
        {
            rigidBody.velocity -= (Vector2)(myTransform.up * backwardSpeed * Time.deltaTime);
        }
        else if (moveInput > 0)
        {
            float targetSpeed = moveInput * maxSpeed;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                targetSpeed *= sprintSpeed / maxSpeed;
            }

            float accelerationRate = acceleration * Time.deltaTime;
            float decelerationRate = deceleration * Time.deltaTime;

            if (rigidBody.velocity.magnitude < targetSpeed)
            {
                rigidBody.velocity += (Vector2)(myTransform.up * accelerationRate);
                if (rigidBody.velocity.magnitude > targetSpeed)
                {
                    rigidBody.velocity = (Vector2)(myTransform.up * targetSpeed);
                }
            }
            else if (rigidBody.velocity.magnitude > targetSpeed)
            {
                rigidBody.velocity -= rigidBody.velocity.normalized * decelerationRate;
                if (rigidBody.velocity.magnitude < targetSpeed)
                {
                    rigidBody.velocity = (Vector2)(myTransform.up * targetSpeed);
                }
            }

            animator.SetBool("isMoving", true);
            animator.SetBool("isSprinting", Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
        }
        else
        {
            float decelerationRate = deceleration * Time.deltaTime;
            if (rigidBody.velocity.magnitude > decelerationRate)
            {
                rigidBody.velocity -= rigidBody.velocity.normalized * decelerationRate;
            }
            else
            {
                rigidBody.velocity = Vector2.zero;
            }

            animator.SetBool("isMoving", false);
            animator.SetBool("isSprinting", false);
        }
    }
    */
}
