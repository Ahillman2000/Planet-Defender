using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;

    public int damage = 10;

    [SerializeField] float attackCooldown = 2.5f;
    float currentAttackCooldown;
    [SerializeField] float minDistanceFromPlayer = 1f;

    [SerializeField] float speed = 5;

    GameObject player;
    Rigidbody2D rb;
    RoundManager roundManagerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();

        roundManagerScript = GameObject.Find("GameManager").GetComponent<RoundManager>();
    }

    void Update()
    {
        Move();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        AttackPlayer(collision);
    }

    private void Move()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) > minDistanceFromPlayer)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        Vector2 lookDir = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void AttackPlayer(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerStats = collision.gameObject.GetComponent<Player>();

            if (currentAttackCooldown <= 0)
            {
                playerStats.TakeDamage(damage);
                currentAttackCooldown = attackCooldown;
            }
            else
            {
                currentAttackCooldown -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        roundManagerScript.enemyCount--;
        Destroy(this.gameObject);
    }
}
