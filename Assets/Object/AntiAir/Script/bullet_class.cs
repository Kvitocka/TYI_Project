using System.Collections;
using UnityEngine;

public class bullet_class : MonoBehaviour
{
    public Transform Aimer;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float reloadTime = 5f;
    private bool isReloading = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isReloading)
        {
            Shoot();
            StartCoroutine(Reload());
        }
    }

  void Shoot()
{
    GameObject bullet = Instantiate(bulletPrefab, Aimer.position, Aimer.rotation);
    Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
    
    bulletRb.AddForce(Aimer.forward * bulletSpeed, ForceMode.VelocityChange);
    
}



    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }
}
