using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AntiAirMachine : MonoBehaviour
{
    [SerializeField] private String trackedObjectsTag;

    private TurretComponent turretComponent;

    private List<GameObject> collideObjects;
    private bool needToTrack;

    private void Awake()
    {
        turretComponent = GetComponentInChildren<TurretComponent>();
    }

    void Start()
    {
        collideObjects = new List<GameObject>();
        needToTrack = false;
    }

    void Update()
    {
        if (needToTrack && collideObjects.Count > 0)
        {
            GameObject collideObject = collideObjects[0];
            turretComponent.TargetTo(collideObject.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(trackedObjectsTag))
        {
            needToTrack = true;
            collideObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(trackedObjectsTag))
        {
            collideObjects.Remove(other.gameObject);
            
            if (collideObjects.Count == 0)
            { 
                needToTrack = false;
            }
        }
    }
}
