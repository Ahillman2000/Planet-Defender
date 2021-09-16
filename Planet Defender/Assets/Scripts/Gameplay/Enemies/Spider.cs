using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public float projectileForce = 20f;

    public float rateOfFire = 2f;
    private float fireCooldown = 0;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(fireCooldown >= rateOfFire)
        {
            Shoot();

            fireCooldown = 0;
        }
        else
        {
            fireCooldown += Time.fixedDeltaTime;
        }
    }

    private void Shoot()
    {
        //Vector3 _newDir;
        
        GameObject _projectile = Instantiate(projectilePrefab, firePoint.position + (firePoint.rotation * new Vector3(-0.6f, 0, 0)), Quaternion.Euler(0, 0, 45) * firePoint.rotation);
        
        
        /*Rigidbody2D _projectile_rb = _projectile.GetComponent<Rigidbody2D>();
        _newDir = Quaternion.Euler(0, 0, 45) * transform.up;
        _projectile_rb.AddForce(_newDir.normalized * projectileForce, ForceMode2D.Impulse);*/

        GameObject _projectile2 = Instantiate(projectilePrefab, firePoint.position + (firePoint.rotation * new Vector3(0, 0, 0)), Quaternion.Euler(0, 0, 0) * firePoint.rotation);
       
        
        /*Rigidbody2D _projectile_rb2 = _projectile2.GetComponent<Rigidbody2D>();
        _newDir = Quaternion.Euler(0, 0, 0) * transform.up;
        _projectile_rb2.AddForce(_newDir.normalized * projectileForce, ForceMode2D.Impulse);*/

        GameObject _projectile3 = Instantiate(projectilePrefab, firePoint.position + (firePoint.rotation * new Vector3(0.6f, 0, 0)), Quaternion.Euler(0, 0, -45) * firePoint.rotation);
        
        
        /*Rigidbody2D _projectile_rb3 = _projectile3.GetComponent<Rigidbody2D>();
        _newDir = Quaternion.Euler(0, 0, -45) * transform.up;
        _projectile_rb3.AddForce(_newDir.normalized * projectileForce, ForceMode2D.Impulse);*/
    }
}
