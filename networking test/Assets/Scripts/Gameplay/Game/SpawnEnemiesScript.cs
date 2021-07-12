using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesScript : MonoBehaviour
{
    public int enemyCount = 0;
    public int maxEnemies = 0;
    public GameObject[] enemies;

    public float minSpawnX;
    public float minSpawnY;
    public float maxSpawnX;
    public float maxSpawnY;

    void Start()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        } 
    }

    void FixedUpdate()
    {
        if(enemyCount < maxEnemies)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length - 1)], new Vector2(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY)), Quaternion.identity);
        enemyCount++;
    }
}
