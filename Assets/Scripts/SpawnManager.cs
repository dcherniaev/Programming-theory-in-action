using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    public GameObject bossPrefab;

    public int enemyCount;
    public int waveNumber = 1;

    private float spawnRange = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab[0], GenerateSpawnPosition(), powerupPrefab[0].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            if (waveNumber % 3 == 0)
            {
                SpawnBoss();
            }
            else
            {
                SpawnEnemyWave(waveNumber);

            }

            int whichPowerup = Random.Range(0, powerupPrefab.Length);
            Instantiate(powerupPrefab[whichPowerup], GenerateSpawnPosition(), powerupPrefab[whichPowerup].transform.rotation);
        }


    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int whichEnemy = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[whichEnemy], GenerateSpawnPosition(), enemyPrefab[whichEnemy].transform.rotation);
        }
    }

    void SpawnBoss()
    {
            Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
    }


    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
