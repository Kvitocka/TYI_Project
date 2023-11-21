using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretComponent : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45.0f;

    private CannonComponent cannonComponent;

    private bool needRotate;
    private Vector3 targetPosition;

    private void Awake()
    {
        cannonComponent = GetComponentInChildren<CannonComponent>();
    }

    void Start()
    {
        needRotate = false;
    }

    void Update()
    {
        if (needRotate)
        {
            Vector3 direction = targetPosition - transform.position;
            float angleInRad = Mathf.Atan2(direction.z, direction.x);
            float angleInDegr = angleInRad * Mathf.Rad2Deg * -1.0f;

            float angleDiff = Mathf.DeltaAngle(transform.eulerAngles.y, angleInDegr);

            if (Mathf.Abs(angleDiff) > 0f)
            {
                float rotationDirection = Mathf.Sign(angleDiff);

                float rotationAmount = rotationSpeed * Time.deltaTime * rotationDirection;

                transform.Rotate(0f, rotationAmount, 0f);
            }
        }
    }

    public void TargetTo(Vector3 coordinate)
    {
        targetPosition = coordinate;
        needRotate = true;
        cannonComponent.TargetTo(coordinate);
    }
}
