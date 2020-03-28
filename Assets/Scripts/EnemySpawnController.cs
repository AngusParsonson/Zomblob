using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnArea;

    public float spawnInterval = 2.0f;
    private float timeSinceSpawn = 0.0f;

    private float xSpawnMin;
    private float xSpawnMax;
    private float zSpawnMin;
    private float zSpawnMax;

    void Start()
    {
        xSpawnMin = spawnArea.GetComponent<MeshRenderer>().bounds.min.x;
        xSpawnMax = spawnArea.GetComponent<MeshRenderer>().bounds.max.x;
        zSpawnMin = spawnArea.GetComponent<MeshRenderer>().bounds.min.z;
        zSpawnMax = spawnArea.GetComponent<MeshRenderer>().bounds.max.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceSpawn >= spawnInterval)
        {
            spawnEnemy();
        }
        timeSinceSpawn += Time.deltaTime;
    }

    private void spawnEnemy()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(xSpawnMin, xSpawnMax), 1f, Random.Range(zSpawnMin, zSpawnMax));
        Instantiate(enemyPrefab, spawnPoint, transform.rotation);
        timeSinceSpawn = 0;
    }
}
