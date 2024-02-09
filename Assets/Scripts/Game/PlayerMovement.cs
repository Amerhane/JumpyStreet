using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 nextDirection;
    Vector3 currentPosition;

    Rigidbody rb;
    public float jumpForce;
    public float moveSpeed;
    public float rotationSpeed;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        jumpForce = 5f;
        moveSpeed = 5f;
        rotationSpeed = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != new Vector3(currentPosition.x, transform.position.y, currentPosition.z) + nextDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentPosition.x, transform.position.y, currentPosition.z) + nextDirection, moveSpeed * Time.deltaTime);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(nextDirection), rotationSpeed * Time.deltaTime);
        }
        else
        {
            nextDirection = Vector3.zero;
            currentPosition = transform.position;
            currentPosition.x = Mathf.Round(currentPosition.x);
            currentPosition.y = Mathf.Round(currentPosition.y);

            
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                nextDirection.z = Input.GetAxisRaw("Horizontal");
                Debug.Log(nextDirection);
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                nextDirection.x = -Input.GetAxisRaw("Vertical");
                Debug.Log("Vertical");
            }
        }


    }

    void Move()
    {
        rb.AddForce(0, jumpForce, 0);
    }

}
