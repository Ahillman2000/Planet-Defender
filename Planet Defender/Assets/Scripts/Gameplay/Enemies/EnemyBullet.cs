using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 10;
    [SerializeField] float velocity = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("hit enemy");
            Destroy(this.gameObject);

            Player playerStats = collision.gameObject.GetComponent<Player>();
            playerStats.TakeDamage(damage);
        }
    }

    private void Update()
    {
        this.transform.position += this.transform.up * velocity * Time.deltaTime;

        Destroy(this.gameObject, 3f);
    }
}
