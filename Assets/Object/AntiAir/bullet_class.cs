using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_class : MonoBehaviour
{
    public Transform Aimer;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f; // Adjust this value to set the fire rate (in seconds).

    private float nextFireTime;

    void Update()
    {
            Shoot();
            nextFireTime = Time.time + 1.0f / fireRate;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, GameObject.position, GameObject.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.AddForce(GameObject.forward * bulletSpeed, ForceMode.VelocityChange);
        }
    }
}
