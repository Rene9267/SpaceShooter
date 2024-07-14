using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Size of the spawner Area")]
    public Vector3 SpawnerSize;

    [Header("Rate of Spawn")]
    public float SpawnRate = 1f;

    [Header("Module to Spawn")]
    [SerializeField] private GameObject asteroidModel;

    private float spawnTimer = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, SpawnerSize);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > SpawnRate)
        {
            spawnTimer = 0f;
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        //set random transfom
        Vector3 spawnPoint = transform.position + new Vector3(UnityEngine.Random.Range(-SpawnerSize.x / 2, SpawnerSize.x / 2),
                                                              UnityEngine.Random.Range(-SpawnerSize.y / 2, SpawnerSize.y / 2),
                                                              UnityEngine.Random.Range(-SpawnerSize.z / 2, SpawnerSize.z / 2));

        GameObject asteroid = Instantiate(asteroidModel, spawnPoint, transform.rotation);
        asteroid.transform.SetParent(this.transform);
    }
}
