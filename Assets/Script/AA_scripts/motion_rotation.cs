using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion_rotation : MonoBehaviour
{
    public float targetAngleY = 90f; // The target Y-angle
    public float rotationSpeed = 50f; // The rotation speed

    void Update()
    {
        // Calculate the current angle of the object around the Y-axis
        float currentAngleY = transform.eulerAngles.y;

        // Calculate the angle difference between the current angle and the target angle
        float angleDiff = Mathf.DeltaAngle(currentAngleY, targetAngleY);

        // Check if the angle difference is not negligible
        if (Mathf.Abs(angleDiff) > 0f)
        {
            // Determine the direction of rotation based on the angle difference
            float rotationDirection = Mathf.Sign(angleDiff);

            // Calculate the rotation amount based on the rotation speed and the direction
            float rotationAmount = rotationSpeed * Time.deltaTime * rotationDirection;

            // Rotate the object by the calculated amount around the Y-axis
            transform.Rotate(0f, rotationAmount, 0f);
        }
    }
}
