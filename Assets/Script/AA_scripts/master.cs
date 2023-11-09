using System;
using UnityEngine;

public class Master : MonoBehaviour
{
    public String Tag;
    public Transform Target;
    public MotionRotation motionRotationTurret;
    public MotionRotation motionRotationcannon;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, transform.rotation);

        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag(Tag))
            {
                Vector3 targetDirection = Target.position - transform.position;

                float angleToTargetY = Vector3.SignedAngle(transform.right, targetDirection, transform.up);
                float angleToTargetZ = Vector3.Angle(transform.right, targetDirection);

                motionRotationTurret.motionRotation_Y(angleToTargetY, 50f);
                motionRotationcannon.motionRotation_Z(angleToTargetZ, 50f);
            }
        }
    }
}