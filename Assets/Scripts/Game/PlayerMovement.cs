using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] bool isJumping;
    Vector3 currentPosition;
    Vector3 inputVector;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isJumping = false;
        currentPosition = transform.position;
        inputVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.W) && !isJumping)
       {
            inputVector += currentPosition;
            Quaternion targetRotation = Quaternion.LookRotation(inputVector - currentPosition);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.3f);
            isJumping = true;
            Jumping();
       }
    }

    public IEnumerator Jumping()
    {
        yield return new WaitForSeconds(0.75f);
        isJumping = false;
    }
}
