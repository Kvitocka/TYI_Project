using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AntiAirMachine : MonoBehaviour
{
    [SerializeField] private String trackedObjectsTag;

    public See see;

    private TurretComponent turretComponent;

    public List<GameObject> collideObjects;
    private bool needToTrack;
    public AimSystem aimSystem;
    public bullet_class bullet_class;
    public Transform Connection;

    private bool WosStart = false;


    void Start()
    {
        turretComponent = GetComponentInChildren<TurretComponent>();
        collideObjects = new List<GameObject>();
        needToTrack = false;
    }

    void Update()
    {
        if (needToTrack && collideObjects.Count > 0 && WosStart)
        {
            GameObject collideObject = collideObjects[0];
            Vector3 point = aimSystem.coord(collideObject.transform.position, Connection.transform.position);
            turretComponent.TargetTo(point);
            bullet_class.Shoot();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(trackedObjectsTag) && see.CanISee(other))
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
