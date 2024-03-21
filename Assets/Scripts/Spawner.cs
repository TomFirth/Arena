using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Vector3 spawnRange;
    public float spawnInterval = 1f;
    public int maxContestants = 3;
    public int currentContestants = 0;

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f && currentContestants < maxContestants)
        {
            SpawnPrefab();
            timer = spawnInterval;
        }
    }

    void SpawnPrefab()
    {
        Vector3 randomSpawnPosition = transform.position + new Vector3(Random.Range(-spawnRange.x, spawnRange.x),
                                                                      Random.Range(-spawnRange.y, spawnRange.y),
                                                                      Random.Range(-spawnRange.z, spawnRange.z));
        // find gamespace area
        Instantiate(prefabToSpawn, randomSpawnPosition, Quaternion.identity);
        currentContestants++;
    }
}
