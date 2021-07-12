using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float damage = 100f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit enemy");
            Destroy(this.gameObject);

            Enemy enemyStats = collision.gameObject.GetComponent<Enemy>();
            enemyStats.TakeDamage(damage);
        }
    }

    private void Update()
    {
        Destroy(this.gameObject, 3f);
    }
}
