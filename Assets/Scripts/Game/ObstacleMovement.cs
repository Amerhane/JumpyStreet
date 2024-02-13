using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// General movement script for moving obstacles (Trucks, Busses, Cars, Logs)

public class ObstacleMovement : MonoBehaviour
{
    private Rigidbody obstacleRB;
    bool isCarFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
        isCarFlipped = gameObject.transform.rotation.eulerAngles.y >= 170 ? true : false;
        Debug.Log(isCarFlipped);

        obstacleRB = GetComponent<Rigidbody>();
        obstacleRB.freezeRotation = true;

        MoveForward();
    }

    void MoveForward()
    {
        int setZCord = 1;

        if (isCarFlipped)
        {
            Debug.Log(true);
            setZCord *= -1;
            Debug.Log("Z CORD " + setZCord);
        }
        if (obstacleRB != null)
        {
            obstacleRB.AddForce(new Vector3(0, 0, setZCord) * SetObstacleSpeed(), ForceMode.Force);
        }
    }

    float SetObstacleSpeed()
    {
        float speed = 1f;

        // Maximum and minimum speeds vary based on obstacle
        if (gameObject.CompareTag("LargeObstacle")) // Trucks and Busses
        {
            // Speed is between 80 and 200
            speed = Random.Range(80f, 200f);
        }
        if (gameObject.CompareTag("SmallObstacle")) // Cars
        {
            // Speed is between 100 and 300
            speed = Random.Range(100f, 300f);
        }
        if (gameObject.CompareTag("WaterObstacle")) // Logs
        {
            // Speed is between 50 and 125
            speed = Random.Range(50f, 125f);
        }
        return speed;
    }
}
