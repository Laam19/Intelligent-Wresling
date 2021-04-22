using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManazar : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange=9;
    public int enemyCount;
    void Start()
    {
        SpawnEnemyWave(3);
    }

    private void SpawnEnemyWave(int enemiesTOSpawn)
    {
        for(int i = 0; i < enemiesTOSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);

        }

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(1);
        }
    }
    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosZ, 0, spawnPosZ);
        return randomPos;
    }
}
