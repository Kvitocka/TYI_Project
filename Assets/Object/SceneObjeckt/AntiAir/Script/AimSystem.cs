using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    private Vector3 oldPosition= new Vector3(0,0,0);
    private float BulletSpeed = 100f;
    private float TargetSpeed = 10f;

    public Vector3 coord(Vector3 coordinate, Vector3 myPosition)
    {
        Vector3 actualPosition = coordinate;
        Vector3 targetVector = actualPosition - oldPosition;

        for(int i=0;i<111;i++)
        {
            float targetDistance = Vector3.Distance(actualPosition, myPosition);
            Debug.Log(actualPosition+ "-"+ myPosition);


            float time = targetDistance/BulletSpeed;

            Vector3 nextPosition = actualPosition + (targetVector * TargetSpeed * time);

            float targetPath = Vector3.Distance(nextPosition, actualPosition);
            float bulletPath = Vector3.Distance(nextPosition, myPosition);

            if(targetPath/TargetSpeed >= 0.8*bulletPath/BulletSpeed && targetPath/TargetSpeed <= 1.2*bulletPath/BulletSpeed)
            {
                
                return nextPosition;
            }
            actualPosition = nextPosition;

        }
        oldPosition = actualPosition;
        return new Vector3(0,0,0);
    }
}
