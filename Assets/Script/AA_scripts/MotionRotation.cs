using UnityEngine;

public class MotionRotation : MonoBehaviour
{
     public void motionRotation_Y(float targetAngle, float rotationSpeed)
    {
        float angleDiff = Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle);

        if (Mathf.Abs(angleDiff) > 0f)
        {
            float rotationDirection = Mathf.Sign(angleDiff);

            float rotationAmount = rotationSpeed * Time.deltaTime * rotationDirection;

            transform.Rotate(0f, rotationAmount, 0f);
        }
    }

    public void motionRotation_Z(float targetAngle, float rotationSpeed)
    {
        float angleDiff = Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle);

        if (Mathf.Abs(angleDiff) > 0f)
        {
            float rotationDirection = Mathf.Sign(angleDiff);

            float rotationAmount = rotationSpeed * Time.deltaTime * rotationDirection;

            transform.Rotate(0f, 0f, rotationAmount);
        }
    }

}