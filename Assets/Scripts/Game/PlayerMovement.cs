using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float jumpForce = 100f;
    public float groundCheckDistance = 0.3f;
    public float obstacleCheckDistance = 2.0f;
    bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        if (Physics.Raycast((transform.position + Vector3.up * 0.1f), Vector3.down, groundCheckDistance) || Physics.Raycast((transform.position + Vector3.up * 0.1f), Vector3.forward, obstacleCheckDistance)) // second part of if statement can be used to check for obstacles in front of player
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        if (isGrounded) 
        { 
            if(Input.GetKeyDown(KeyCode.W))
            {
                AdjustPositionAndRotation(new Vector3(0, 0, 0));
                rb.AddForce(new Vector3(jumpForce, jumpForce, 0));                
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                AdjustPositionAndRotation(new Vector3(0, 180, 0));
                rb.AddForce(new Vector3(-jumpForce, jumpForce, 0));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                AdjustPositionAndRotation(new Vector3(0, -90, 0));
                rb.AddForce(new Vector3(0, jumpForce, jumpForce));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                AdjustPositionAndRotation(new Vector3(0, 90, 0));
                rb.AddForce(new Vector3(0, jumpForce, -jumpForce));
                
            }
        }
    }

    void AdjustPositionAndRotation(Vector3 newRotation)
    {
        rb.velocity = Vector3.zero;
        transform.eulerAngles = newRotation;
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
    }
}