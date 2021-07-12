using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float speed = 5;
    public float damage = 10;

    public float minDistanceFromPlayer = 1f;
    GameObject player;

    Rigidbody2D rb;

    SpawnEnemiesScript spawnEnemiesScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();

        spawnEnemiesScript = GameObject.Find("GameManager").GetComponent<SpawnEnemiesScript>();
    }

    void Update()
    {
        if(Vector2.Distance(this.transform.position, player.transform.position) > minDistanceFromPlayer)
        {
            //this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        Vector2 lookDir = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        spawnEnemiesScript.enemyCount--;
        Destroy(this.gameObject);
    }
}
