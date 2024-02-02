using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    [SerializeField] private GameObject grassTerrain;
    [SerializeField] private GameObject riverTerrain;
    [SerializeField] private GameObject roadTerrain;
    
    // Used for picking terrain
    private int firstRand = 0;
    private int secondRand = 0;
    private int storedRand = 0;
    // Used for checking distance from farthest terrain tile
    private int distPlayer = 12;
    // Used for setting the position of the instantiation of the game object
    private Vector3 instPos = new Vector3(0, 0, 0);

    // Update is called once per frame
    private void Update()
    {
        GenerateTerrain();
    }

    private void GenerateTerrain()
    {
        if (Input.GetKeyUp(KeyCode.W)) // Used for testing, will merge with player input code later
        {
            GenerateFirstRand();

            if (firstRand <= 33) // Grass is generated if the number is in the first 33% of the range
            {
                storedRand = firstRand;
                secondRand = Random.Range(2, 9);
                for (int i = 0; i < secondRand; i++)
                {
                    instPos = new Vector3(distPlayer, 0, 0);
                    distPlayer += 1;
                    GameObject grassInst = Instantiate(grassTerrain) as GameObject;
                    grassInst.transform.position = instPos;
                }
            }
            if (firstRand >= 34 && firstRand <= 85) // Roads are generated if the number in the range of 34% and 85%
            {
                storedRand = firstRand;
                secondRand = Random.Range(2, 7);
                for (int i = 0; i < secondRand; i++)
                {
                    instPos = new Vector3(distPlayer, -0.1f, 0);
                    distPlayer += 1;
                    GameObject roadInst = Instantiate(roadTerrain) as GameObject;
                    roadInst.transform.position = instPos;
                }
            }
            if (firstRand >= 86) // Rivers are generated if the number is in the last 15% of the range (86%+)
            {
                storedRand = firstRand;
                secondRand = Random.Range(2, 6);
                for (int i = 0; i < secondRand; i++)
                {
                    instPos = new Vector3(distPlayer, -0.2f, 0);
                    distPlayer += 1;
                    GameObject riverInst = Instantiate(riverTerrain) as GameObject;
                    riverInst.transform.position = instPos;
                }
            }
        }
    }

    // Method is used to prevent the same terrain type from being used twice in a row
    private void GenerateFirstRand()
    {
        firstRand = Random.Range(1, 101);

        if (firstRand <= 33 && storedRand <= 33 && storedRand != 0)
        {
            do
            {
                firstRand = Random.Range(1, 101);
            } while (firstRand <= 33);
        }
        else if (firstRand >= 34 && firstRand <= 85 && storedRand >= 34 && storedRand <= 85)
        {
            do
            {
                firstRand = Random.Range(1, 101);
            } while (firstRand >= 34 && firstRand <= 85);
        }
        else if (firstRand >= 86 && storedRand >= 86)
        {
            do
            {
                firstRand = Random.Range(1, 101);
            } while (firstRand <= 86);
        }
    }
}
