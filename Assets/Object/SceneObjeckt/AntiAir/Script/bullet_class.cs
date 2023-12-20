using System;
using System.Collections;
using UnityEngine;

public class bullet_class : MonoBehaviour
{
    public Transform Aimer;
    public GameObject bulletPrefab;
    public static Action OnTach;
    public float bulletSpeed = 100f;
    public float reloadTime = 0.1f;
    private bool isReloading = false;
    public float MasOil = 5f;
    public float SpendOil = 5f;
    public float MasCorps = 5f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isReloading)
        {
            Shoot();
            StartCoroutine(Reload());
            OnTach?.Invoke();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, Aimer.position, Aimer.rotation);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        ControlMas controlMas = bullet.GetComponent<ControlMas>();
        

        controlMas.MassCorps=MasCorps;
        controlMas.MassOil=MasOil;
        controlMas.SpendOilForSecond=SpendOil;
    
        bulletRb.AddForce(Aimer.right * bulletSpeed, ForceMode.VelocityChange);

    }
    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }

    public void GetBulletSpeed(String s){
         if(s==""){s="0";}
        bulletSpeed=float.Parse(s);
    }

     public void GetMasOil(String s){
         if(s==""){s="0";}
        MasOil=float.Parse(s);
    }
     public void GetSpendOil(String s){
         if(s==""){s="0";}
        SpendOil=float.Parse(s);
    }
     public void GetMasCorps(String s){
         if(s==""){s="0";}
        MasCorps=float.Parse(s);
    }
   
}
