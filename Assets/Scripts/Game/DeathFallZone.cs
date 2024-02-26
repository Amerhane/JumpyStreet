using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFallZone : MonoBehaviour
{
    [SerializeField]
    private Transform playerPosition;

    private void FixedUpdate()
    {
        this.gameObject.transform.position = 
            new Vector3(playerPosition.position.x, -3, playerPosition.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().isDead = true;
        }
    }
}
