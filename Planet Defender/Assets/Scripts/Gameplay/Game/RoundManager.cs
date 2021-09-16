using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundManager : MonoBehaviour
{
    public GameObject[] enemies;
    //public int maxEnemies = 0;
    public int[] maxEnemiesInRound;
    [HideInInspector] public int enemyCount = 0;

    public float minSpawnX;
    public float minSpawnY;
    public float maxSpawnX;
    public float maxSpawnY;

    public int MaxNumberOfRounds;
    [HideInInspector] public int currentRound = 0;

     public TextMeshProUGUI nextRoundText;

    private void Awake()
    {
        MaxNumberOfRounds = maxEnemiesInRound.Length - 1;
    }

    void Start()
    {
        SpawnEnemy();
        nextRoundText.enabled = false;
    }

    void FixedUpdate()
    {
        if (currentRound < MaxNumberOfRounds)
        {
            if (enemyCount <= 0)
            {
                StartCoroutine(NextRound());
                SpawnEnemy();
            }
        }
    }

    /*void NextRound()
    {
        currentRound++;
        nextRoundText.enabled = true;
        nextRoundText.text = "Round" + currentRound + 1;

        nextRoundText.enabled = false;
    }*/

    IEnumerator NextRound()
    {
        currentRound++;

        nextRoundText.enabled = true;
        nextRoundText.text = "Round: " + (currentRound + 1);

        yield return new WaitForSeconds(2.5f);

        nextRoundText.enabled = false;
    }

    void SpawnEnemy()
    {
        // set number of enemies each round
        /*for (int i = 0; i < maxEnemies; i++)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY)), Quaternion.identity);
            enemyCount++;
        }*/

        for (int i = 0; i < maxEnemiesInRound[currentRound]; i++)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY)), Quaternion.identity);
            enemyCount++;
        }
    }
}
