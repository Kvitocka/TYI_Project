using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonComponent : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45.0f;
    [SerializeField] private float maxAngle = 70.0f;
    [SerializeField] private float minAngle = 0.0f;

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

            if (transform.rotation.eulerAngles.z <= targetAngle + 0.5 && transform.rotation.eulerAngles.z >= targetAngle - 0.5)
            {
                needRotate = false;
            }
        }
    }
    
    private float CalculateDistanceNoSqrt(Vector3 point1, Vector3 point2)
    {
        float deltaX = point2.x - point1.x;
        float deltaY = point2.y - point1.y;
        return deltaX * deltaX + deltaY * deltaY;
    }

    public void TargetTo(Vector3 coordinate)
    {
        needRotate = true;

        Vector3 point = new Vector3(coordinate.x, transform.position.y);
        float catenary  = CalculateDistanceNoSqrt(transform.position, point);
        float hypotenuse = CalculateDistanceNoSqrt(coordinate, transform.position);
        Debug.Log("catenary: " + catenary);
        Debug.Log("hypotenuse: "  + hypotenuse);
        targetAngle = Mathf.Acos(catenary  / hypotenuse) * Mathf.Rad2Deg;
        targetAngle -= targetAngle / 5.0f;
        Debug.Log(targetAngle);

        if (targetAngle > maxAngle) targetAngle = maxAngle;
    }
}
