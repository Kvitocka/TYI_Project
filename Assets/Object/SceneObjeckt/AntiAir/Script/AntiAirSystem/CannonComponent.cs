using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CannonComponent : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45.0f;
    [SerializeField] private float maxAngle = 70.0f;
    [SerializeField] private float minAngle = 0.0f;

    public Transform CannonPosition;

    private bool needRotate;
    private float targetAngle;
    private bool WosStart = false;

    void Start()
    {
        needRotate = false;
        targetAngle = 0.0f;
    }

    void Update()
    {
        if (needRotate && WosStart)
        {
            float currentAngle = transform.rotation.eulerAngles.z;
            float angleDifference = targetAngle - currentAngle;
            float rotationDirection = Mathf.Sign(angleDifference);
            float rotationThisFrame = rotationSpeed * Time.deltaTime * rotationDirection;

            transform.Rotate(0, 0, rotationThisFrame);

            // ???? ???? ??????? 

            if (transform.rotation.eulerAngles.z <= targetAngle + 0.0001 && transform.rotation.eulerAngles.z >= targetAngle - 0.0001)
            {
                needRotate = false;
            }
        }
    }
    public void TargetTo(Vector3 coordinate)
    {
        needRotate = true;

        float hip =(float) Vector3.Distance(  coordinate , CannonPosition.transform.position );
        float kat =(float) Vector3.Distance( new Vector3 (coordinate.x,CannonPosition.transform.position.y,coordinate.z)  , CannonPosition.transform.position );
        targetAngle = (float)(Math.Acos(kat/hip)*180/Math.PI);



        if (targetAngle > maxAngle) {targetAngle = maxAngle;}
        if ( targetAngle < minAngle) {targetAngle = minAngle;} 

    }

    public void GetCannonSpeedRotation(String s){
         if(s==""){s="0";}
        rotationSpeed=float.Parse(s);
    }
    public void GetCannonRotation(String s){
         if(s==""){s="0";}
        transform.Rotate(0f, 0f, float.Parse(s));
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
