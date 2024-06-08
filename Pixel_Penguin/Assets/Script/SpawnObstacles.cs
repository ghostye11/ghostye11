using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float initialTimeBetweenSpawn; 
    public float timeDecreaseRate; 
    private float spawnTime;

    void Start()
    {
        spawnTime = Time.time + initialTimeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            DecreaseSpawnTime();
            spawnTime = Time.time + initialTimeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }

    void DecreaseSpawnTime()
    {
        initialTimeBetweenSpawn -= timeDecreaseRate;

        if (initialTimeBetweenSpawn < 0.3f)
        {
            initialTimeBetweenSpawn = 0.3f;
        }
    }
}
