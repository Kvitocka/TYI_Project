using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(SphereCollider))]
public class Rocket_system : MonoBehaviour
{
    [SerializeField] private String trackedObjectsTag;
    public List<GameObject> collideObjects;  
    private bool isReloading = false;
    public float reloadTime = 50f;
    public GameObject bulletPrefab;

    private bool WosStart=false;
    void Update()
    {
        if(collideObjects.Count != 0 && Input.GetMouseButtonDown(0) && !isReloading && WosStart)
        {
            GameObject rocket = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody bulletRb = rocket.GetComponent<Rigidbody>();

            bulletRb.AddForce(Vector3.up * 50.0f, ForceMode.Impulse);
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

}
