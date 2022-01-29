using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public int enemycount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    // Diffrence between void and private vector 3:
    // Vector3 gives us a *position, but void only tells us what will** happen *(this case random position betweel some barriers) **(our in our code)


    void Start()
    {
        // spawn enemy to random place
        Instantiate(powerupPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        spawnEnemyWave(waveNumber);
           
    }
    void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // spawn enemy to random place
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }
    void Update()
    {
        enemycount = FindObjectsOfType<Enemy>().Length;
        if (enemycount == 0)
        {
            Instantiate(powerupPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
            waveNumber++;
            spawnEnemyWave(waveNumber);
        }
    }
    private Vector3 GenerateRandomPosition()
    {
        // this makes random values
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        // this makes them in to the game 
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

}
