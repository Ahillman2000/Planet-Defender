using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float velocity = 100f;
    public int damage = 25;

    public GameObject hitImpactPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("hit enemy");
            Destroy(this.gameObject);

            Enemy enemyStats = collision.gameObject.GetComponent<Enemy>();
            enemyStats.TakeDamage(damage);
        }

        Destroy(this.gameObject);
        GameObject hitImpactEffect = Instantiate(hitImpactPrefab, transform.position, Quaternion.identity);
        Destroy(hitImpactEffect, .4f);
    }

    private void Update()
    {
        this.transform.position += this.transform.up * velocity * Time.deltaTime;

        Destroy(this.gameObject, 3f);
    }
}
