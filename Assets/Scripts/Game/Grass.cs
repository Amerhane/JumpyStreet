using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [Header("Plants Prefabs")]
    [SerializeField] private GameObject treePref;
    [SerializeField] private GameObject bushPref;

    private void Start()
    {
        DetermineSpawn();
    }

    private void DetermineSpawn()
    {
        // trees and bushes have a 40% chance of spawning
        float rand = Random.Range(0f, 100f);

        if (rand >= 60)
        {
            SpawnObstacles();
        }
    }

    private void SpawnObstacles()
    {
        // spawn a max of 8 obstacles, sift using bools to determine whether to spawn an obstacle on that tile or not
        float currentZ = -4.5f;
        float spawnedObstacles = 0;

        for (int i = 0; i < 9; i++) 
        {
            float shouldPlantSpawn = Random.Range(0f, 100f);
            if (shouldPlantSpawn >= 70)
            {
                if (spawnedObstacles < 8)
                {
                    float determinePlant = Random.Range(0f, 100f);
                    if (determinePlant <= 50)
                    {
                        Instantiate(treePref, new Vector3(transform.position.x, 0f, currentZ), transform.rotation);
                    }
                    else
                    {
                        Instantiate(bushPref, new Vector3(transform.position.x, 0f, currentZ), transform.rotation);
                    }
                    spawnedObstacles++;
                }
            }
            currentZ += 1;
        }
    }
}
