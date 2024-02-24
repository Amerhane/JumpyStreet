using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// General movement script for moving obstacles (Trucks, Busses, Cars, Logs)

public class ObstacleMovement : MonoBehaviour
{
    private Rigidbody obstacleRB;
    bool isCarFlipped = false;

    public float rowSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        isCarFlipped = gameObject.transform.rotation.eulerAngles.y >= 170 ? true : false;

        obstacleRB = GetComponent<Rigidbody>();
        obstacleRB.freezeRotation = true;
        MoveForward();
    }

    private void MoveForward()
    {
        int setZCord = 1;

        if (isCarFlipped)
        {
            setZCord *= -1;
        }
        if (obstacleRB != null)
        {
            obstacleRB.AddForce(new Vector3(0, 0, setZCord) * rowSpeed, ForceMode.Force);
        }
    }
}
