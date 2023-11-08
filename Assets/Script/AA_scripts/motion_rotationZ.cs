using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion_rotationZ : MonoBehaviour
{
    public float targetAngleZ = 90f; 
    public float rotationSpeed = 50f; 

    void Update()
    {

        float currentAngleZ = transform.eulerAngles.z;

        float angleDiff = Mathf.DeltaAngle(currentAngleZ, targetAngleZ);

        if (Mathf.Abs(angleDiff) > 0f)
        {
            float rotationDirection = Mathf.Sign(angleDiff);

            float rotationAmount = rotationSpeed * Time.deltaTime * rotationDirection;

            transform.Rotate(0f, 0f, rotationAmount);
        }
    }

}
