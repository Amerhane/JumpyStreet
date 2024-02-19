using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] float xJumpForce = 100f;
    [SerializeField] float yJumpForce = 100f;
    [SerializeField] float groundCheckDistance = 0.3f;
    [SerializeField] float obstacleCheckDistance = 2.0f;
    bool isGrounded = false;

    [SerializeField] GameObject respawn;

    RaycastHit hit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        if (Physics.BoxCast((transform.position + Vector3.up * 0.1f), transform.lossyScale / 2, Vector3.down, out hit, transform.rotation, groundCheckDistance) || Physics.BoxCast((transform.position + Vector3.up * 0.1f), transform.lossyScale / 2, Vector3.left, out hit, transform.rotation, obstacleCheckDistance) || Physics.BoxCast((transform.position + Vector3.up * 0.1f), transform.lossyScale / 2, Vector3.right, out hit, transform.rotation, obstacleCheckDistance))
        {
            isGrounded = true;
            Debug.Log("should jump");

            if(hit.collider.tag == "WaterObstacle")
            {
                transform.position = respawn.transform.position;
            }

            if(hit.collider.tag == "LargeObstacle" || hit.collider.tag == "SmallObstacle")
            {
                transform.position = respawn.transform.position;
            }
        }
        else
        {
            isGrounded = false;
            Debug.Log("should't jump");
        }


        if (isGrounded) 
        { 
            if(Input.GetKeyDown(KeyCode.W))
            {
                AdjustPositionAndRotation(new Vector3(0, 0, 0));
                rb.AddForce(new Vector3(xJumpForce, yJumpForce, 0));                
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                AdjustPositionAndRotation(new Vector3(0, 180, 0));
                rb.AddForce(new Vector3(-xJumpForce, yJumpForce, 0));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                AdjustPositionAndRotation(new Vector3(0, -90, 0));
                rb.AddForce(new Vector3(0, xJumpForce, yJumpForce));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                AdjustPositionAndRotation(new Vector3(0, 90, 0));
                rb.AddForce(new Vector3(0, xJumpForce, -yJumpForce));
                
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