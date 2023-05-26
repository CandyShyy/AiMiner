using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    private bool isShooting = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
            Shoot();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        if (isShooting)
        {
            Invoke("Shoot", 0.1f); // Adjust the delay between shots here (in seconds)
        }
    }
}
