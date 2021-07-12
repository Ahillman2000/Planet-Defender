using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bullet_rb = bullet.GetComponent<Rigidbody2D>();
            bullet_rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
