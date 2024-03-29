using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    [Header("Water Prefabs")]
    [SerializeField] private GameObject logPref;

    private float randomSpawnRate = 0f;
    private float rowSpeed = 0f;

    private void Start()
    {
        randomSpawnRate = Random.Range(3f, 7f);
        rowSpeed = Random.Range(50f, 125f);

        FlipOrientation();
        InvokeRepeating("SpawnVehicle", 0f, randomSpawnRate);
    }

    private void SpawnVehicle()
    {
        float zSpawnCord = -7f;

        if (transform.rotation.eulerAngles.y >= 170)
        {
            zSpawnCord *= -1f;
        }

        randomSpawnRate = Random.Range(5f, 7f);

        GameObject spawnedObject = GameObject.Instantiate(logPref, new Vector3(transform.position.x, 0.034f, zSpawnCord), transform.rotation);

        spawnedObject.GetComponent<ObstacleMovement>().rowSpeed = rowSpeed;

        StartCoroutine(DespawnVehicle(spawnedObject));
    }

    private IEnumerator DespawnVehicle(GameObject vehicle)
    {
        yield return new WaitForSeconds(10f);

        Destroy(vehicle);
    }

    // changes the orientation of the road
    private void FlipOrientation()
    {
        int rand = Random.Range(0, 101);

        if (rand >= 50)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
