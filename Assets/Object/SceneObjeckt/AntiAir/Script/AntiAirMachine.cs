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

    private GameObject OldTarget;
    private int oldTargetCode=-1;

    private bool WosStart = false;


    void Start()
    {
        turretComponent = GetComponentInChildren<TurretComponent>();
        collideObjects = new List<GameObject>();
        needToTrack = false;
        OldTarget = new GameObject();
        OldTarget.AddComponent<CauntHunter>();

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

    public int NumberOfCollider(List<GameObject> colider)
    {
        int Namber = 0;
        int minHunter = int.MaxValue;

        for (int i = 0; i < colider.Count; i++)
        {
            CauntHunter cauntHunter = colider[i].gameObject.GetComponent<CauntHunter>();
            if (cauntHunter.caunt < minHunter)
            {
                minHunter = cauntHunter.caunt;
               
            }
        }

        for (int i = 0; i < colider.Count; i++)
        {
            CauntHunter cauntHunter = colider[i].gameObject.GetComponent<CauntHunter>();
            if (cauntHunter.caunt < minHunter)
            {
                minHunter = cauntHunter.caunt;
                Namber = i;
            }
        }

        if (oldTargetCode != colider[Namber].GetComponent<CauntHunter>().myCod)
        {
            Debug.Log("rere");
            colider[Namber].gameObject.GetComponent<CauntHunter>().addCaunt();
            OldTarget.gameObject.GetComponent<CauntHunter>().minusCaunt();
        }

        OldTarget = colider[Namber].gameObject;
        oldTargetCode = colider[Namber].GetComponent<CauntHunter>().myCod;

        return Namber;
    }



}
