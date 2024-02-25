using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Project: JumpyStreet
/// Name: Josiah Glenewinkel
/// Section: SGD 285.4171
/// Instructor: Aurore Locklear
/// Date: 02/25/2024
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] float xJumpForce = 100f;
    [SerializeField] float yJumpForce = 100f;
    [SerializeField] float groundCheckDistance = 0.3f;
    bool isGrounded = false;

    public Vector3 destroyPoint { get; private set; }

    RaycastHit hit;

    public bool isDead; //DEATH BOOL HERE

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        isDead = false;
    }

    void Update ()
    {
        if (Physics.BoxCast((transform.position + Vector3.up * 0.1f), transform.lossyScale / 2, Vector3.down, out hit, transform.rotation, groundCheckDistance))
        {
            isGrounded = true;
            //Debug.Log("should jump");
        }
        else
        {
            isGrounded = false;
            //Debug.Log("should't jump");
        }


        if (isGrounded) 
        { 
            if(Input.GetKeyDown(KeyCode.W))
            {
                
                rb.AddForce(new Vector3(xJumpForce, yJumpForce, 0));
                AdjustPositionAndRotation(new Vector3(0, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                
                rb.AddForce(new Vector3(-xJumpForce, yJumpForce, 0));
                AdjustPositionAndRotation(new Vector3(0, 180, 0));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                
                rb.AddForce(new Vector3(0, yJumpForce, xJumpForce));
                AdjustPositionAndRotation(new Vector3(0, -90, 0));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                
                rb.AddForce(new Vector3(0, yJumpForce, -xJumpForce));
                AdjustPositionAndRotation(new Vector3(0, 90, 0));
            }
        }

        destroyPoint = new Vector3((transform.position.x - 5f), 0f, 0f);
    }

    void AdjustPositionAndRotation(Vector3 newRotation)
    {
        float zPos = Mathf.Sign(transform.position.z) * (Mathf.Abs((int)transform.position.z) + 0.5f);

        rb.velocity = Vector3.zero;
        transform.eulerAngles = newRotation;
        transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, zPos);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("WATER");
            isDead = true;
        }

        if (collision.gameObject.tag == "LargeObstacle" || collision.gameObject.tag == "SmallObstacle")
        {
            Debug.Log("CAR");
            isDead = true;
        }
    }
}