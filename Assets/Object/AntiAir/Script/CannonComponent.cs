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

    void Start()
    {
        needRotate = false;
        targetAngle = 0.0f;
    }

    void Update()
    {
        if (needRotate)
        {
            float currentAngle = transform.rotation.eulerAngles.z;
            float angleDifference = targetAngle - currentAngle;
            float rotationDirection = Mathf.Sign(angleDifference);
            float rotationThisFrame = rotationSpeed * Time.deltaTime * rotationDirection;

            transform.Rotate(0, 0, rotationThisFrame);

            if (transform.rotation.eulerAngles.z <= targetAngle && transform.rotation.eulerAngles.z >= targetAngle)
            {
                needRotate = false;
            }
        }
    }
    
    private float CalculateTan(Vector3 point1, Vector3 point2)
    {
        float deltaX = Math.Abs(point2.x - point1.x);
        float deltaY = Math.Abs(point2.y - point1.y);
        return deltaY/deltaX;
    }

    public void TargetTo(Vector3 coordinate)
    {
        needRotate = true;

        float hip =(float) Vector3.Distance(  coordinate , CannonPosition.transform.position );
        float kat =(float) Vector3.Distance( new Vector3 (coordinate.x,CannonPosition.transform.position.y,coordinate.z)  , CannonPosition.transform.position );
        targetAngle = (float)(Math.Acos(kat/hip)*180/Math.PI);



        //if (targetAngle > maxAngle) {targetAngle = maxAngle;}
        //if ( targetAngle < minAngle) {targetAngle = minAngle;} 

        //targetAngle -= targetAngle / 5.0f;
        Debug.Log(targetAngle);

    }
}
