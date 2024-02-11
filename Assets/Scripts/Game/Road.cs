using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Road : MonoBehaviour
{
    [Header("Vehicle Prefabs")]
    [SerializeField] private GameObject truckPref;
    [SerializeField] private GameObject busPref;
    [SerializeField] private GameObject carPref;

    private float randomSpawnRate = 0f;

    private void Start()
    {
        randomSpawnRate = Random.Range(3f, 7f);

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

        GameObject spawnedObject;
        int selectVehicle = Random.Range(0, 3);

        switch (selectVehicle)
        {
            case 0:
                spawnedObject = GameObject.Instantiate(truckPref, new Vector3(transform.position.x, 0.275f, zSpawnCord), transform.rotation);
                break;
            case 1:
                spawnedObject = GameObject.Instantiate(busPref, new Vector3(transform.position.x, 0.275f, zSpawnCord), transform.rotation);
                break;
            case 2:
                spawnedObject = GameObject.Instantiate(carPref, new Vector3(transform.position.x, 0.275f, zSpawnCord), transform.rotation);
                break;
            default:
                spawnedObject = GameObject.Instantiate(carPref, new Vector3(transform.position.x, 0.275f, zSpawnCord), transform.rotation);
                break;
        }

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
