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

    private GameObject target;

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
            if (target == null) { target = GetTarget(collideObjects); }
            else {
                GameObject collideObject = target;
                Vector3 point = aimSystem.coord(collideObject.transform.position, Connection.transform.position, collideObject.GetComponent<linear_movement>().target_direction, collideObject.GetComponent<linear_movement>().notCorectSpeed, bullet_class.bulletSpeed);
                turretComponent.TargetTo(point);
                bullet_class.Shoot();
            }
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

    public static GameObject GetTarget(List<GameObject> colider)
    {
        for (int a = 0; ; a++) {
        
            for (int b = 0; b < colider.Count; b++)
            {
                CauntHunter CH = colider[b].GetComponent<CauntHunter>();
                if (CH!=null)
                {
                    if (CH.caunt == a )
                    {
                        CH.caunt = CH.caunt + 1;
                        return colider[b].gameObject;
                    }
                }
            }
        }
    }



}
