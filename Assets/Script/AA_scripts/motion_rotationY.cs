using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion_rotationY : MonoBehaviour
{
    public float targetAngleY = 90f; 
    public float rotationSpeed = 50f; 

    void Update()
    {

        float currentAngleY = transform.eulerAngles.y;

        float angleDiff = Mathf.DeltaAngle(currentAngleY, targetAngleY);

        if (Mathf.Abs(angleDiff) > 0f)
        {
            float rotationDirection = Mathf.Sign(angleDiff);

            float rotationAmount = rotationSpeed * Time.deltaTime * rotationDirection;

            transform.Rotate(0f, rotationAmount, 0f);
        }
    }

}
