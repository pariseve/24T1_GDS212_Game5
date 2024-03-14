using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;
    public int numberOfObjects = 3;
    public Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f);

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Randomly select an object from the list
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];

            // Generate a random position within the spawn area
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                0.2f,
                Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
            );

            // Spawn the object at the random position
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }

}
