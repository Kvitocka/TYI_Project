using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction_rotation : MonoBehaviour
{
    Vector3 oldPosition;

    void Start()
    {
        oldPosition = transform.position;
    }

    void Update()
    {
        Vector3 targetVector = transform.position - oldPosition;
        transform.LookAt(targetVector);

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y += 90;
        transform.eulerAngles = currentRotation;

        oldPosition = transform.position;
    }
}