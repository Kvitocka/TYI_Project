using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_class : MonoBehaviour
{
    public Transform Aimer;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        GameObject correctPrefab = bulletPrefab;
        correctPrefab.transform.position =new Vector3 (0f,0f,0f);
        GameObject bullet = Instantiate(bulletPrefab, Aimer.transform, true);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.AddForce(Aimer.forward * bulletSpeed, ForceMode.VelocityChange);
        }
    }
}
