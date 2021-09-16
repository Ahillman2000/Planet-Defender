using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerAcid : MonoBehaviour
{
    public int damage = 1;

    void Start()
    {
        
    }

    // add cooldown for damage

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("enemy in acid (trigger)");

            Player playerStats = collision.gameObject.GetComponent<Player>();
            playerStats.TakeDamage(damage);
        }
    }

    void Update()
    {
        
    }
}
