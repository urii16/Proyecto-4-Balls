using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    private float spawnRange = 9;

    public int enemyCount;
    public int enemyWave = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemyWave);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemyWave(enemyWave);
            SpawnPowerUp(enemyWave);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        float spwanPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spwanPositionX, 0, spawnPositionZ);
        return randomPos;
    }

    private void SpawnEnemyWave(int enemiesNumber)
    {
        for (int i = 0; i < enemiesNumber; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
        
    }

    private void SpawnPowerUp(int enemiesNumber)
    {
        if(enemyWave%5 == 0)
        {
            int numberPowerUp = 1;
            for (int i = 0; i <= numberPowerUp; i++)
            {
                Instantiate(powerUpPrefab, GenerateRandomPosition(), powerUpPrefab.transform.rotation);
            }
            numberPowerUp++;
            
        }
    }
}
