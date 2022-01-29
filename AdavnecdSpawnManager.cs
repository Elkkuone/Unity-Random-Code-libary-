using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // same as under but with an array with size as i want
    public GameObject[] enemies;
    // place to put my powerup to get it working easily
    public GameObject powerup;
    // z location where enemy will spanwn at
    private float zEnemySpawn = 12.0f;
    // max range on x and z
    private float xSpawnRange = 16.0f;
    private float zPowerupRange = 5.0f;
    private float ySpawn = 0.75f;

    // spawn times to invokerepeat
    private float startDelay = 1.0f;
    private float enemySpawnTime = 0.1f;
    private float powerupSpawnTime = 20.0f;
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    void Update()
    {
   
    }
    void SpawnRandomEnemy()
    {
        // randomizes spawns to in or between -5, 5
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        // this is for making the enemies spawn ramdomly (so 0 to 3, and zero is one)
        int ramdomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnpos = new Vector3(randomX, ySpawn, zEnemySpawn);
        // to spawn to a position, spawn it and make sure its rotated propely
        // so spawn a random enemy to our spawnpos, take enemies again and and rotate it propely with transform.rotation
        Instantiate(enemies[ramdomIndex], spawnpos, enemies[ramdomIndex].gameObject.transform.rotation);
    }
    void SpawnPowerup()
    {
        // random x value in between 16,-16
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        // random z value between 5,-5
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);
        // specify location to spawn using values
        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
}
