using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(SphereCollider))]
public class Rocket_system : MonoBehaviour
{
    public List<GameObject> collideObjects; 
    
    private bool isReloading = false;

    public float reloadTime = 50f;

    public float speed=3;

    public float acceleration=0.5f;

    public GameObject bulletPrefab;

    private bool WosStart=false;

    public float MassCorps = 10f;

    public float MassOil = 10f;

    public float SpendOil = 10f;

    public float maxRotationSpeed = 45;

    public float distance=0.5f;

    public bool isRadius=false;

    void Update()
    {
        if(collideObjects.Count != 0 && !isReloading && WosStart)
        {
            GameObject rocket = Instantiate(bulletPrefab, transform.position+new Vector3(-1,2,-1), transform.rotation);

            Rocket_movement rk = rocket.GetComponent<Rocket_movement>();

            ControlMas m = rocket.GetComponent<ControlMas>();

            m.MassCorps = MassCorps;

            m.MassOil = MassOil;

            m.SpendOilForSecond=SpendOil;

            rk.acceleration = acceleration;

            rk.speed = speed;

            rk.target = AntiAirMachine.GetTarget(collideObjects);

            rk.maxRotationSpeed = maxRotationSpeed;

            rk.distance = distance;

            rk.IsRadiu = isRadius;

            rk.Shot();

            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            collideObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            collideObjects.Remove(other.gameObject);
        }
    }

    public void OnEnable()
    {
        StartSimulation.TapStart += StartGame;
    }

    public void OnDisable()
    {
        StartSimulation.TapStart -= StartGame;
    }

    public void StartGame()
    {
        WosStart = true;
    }
    public void SetMasOil(String s)
    {
        if (s == "") { s = "0"; }
        MassOil = float.Parse(s);
    }
    public void SetSpendOil(String s)
    {
        if (s == "") { s = "0"; }
        SpendOil = float.Parse(s);
    }
    public void SetMasСorps(String s)
    {
        if (s == "") { s = "0"; }
        MassCorps = float.Parse(s);
    }
    public void SetMaxRotationSpeed(String s)
    {
        if (s == "") { s = "0"; }
        maxRotationSpeed = float.Parse(s);
    }
    public void SetSpeed(String s)
    {
        if (s == "") { s = "0"; }
        speed = float.Parse(s);
    }
    public void SetAcelleration(String s)
    {
        if (s == "") { s = "0"; }
        acceleration = float.Parse(s);
    }
    public void SetDistance(String s)
    {
        if (s == "") { s = "0"; }
        distance = float.Parse(s);
    }
}
