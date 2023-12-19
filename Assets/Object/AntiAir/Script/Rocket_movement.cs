using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Rocket_movement : MonoBehaviour
{
    [SerializeField] private String trackedObjectsTag;
    private Rocket_system rocket_System;
    private float speed = 100f;
    private float acceleration = 30f;

    public List<GameObject> collideObjects;  


    public void Update()
    {
        GameObject collideObject = collideObjects[0];
        Vector3 targetVector = collideObject.transform.position - transform.position;

        transform.Translate(targetVector * speed * Time.deltaTime);
        speed += acceleration;
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
}
