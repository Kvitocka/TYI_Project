using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction_rotation : MonoBehaviour
{
    private Vector3 oldPosition;

    void Start()
    {
        oldPosition = new Vector3(0,0,0);
    }

    void Update()
    {
        Debug.Log("Old="+oldPosition);
        Debug.Log("New="+transform.position);
        float Xdiff = transform.position.x - oldPosition.x;
        float Ydiff = transform.position.y - oldPosition.y;
        float Zdiff = transform.position.z - oldPosition.z;
        Debug.Log("X="+Xdiff);
        Debug.Log("Y="+Ydiff);
        Debug.Log("Z="+Zdiff);

        Vector3 targetPoint =transform.position + new Vector3(Xdiff,Ydiff,Zdiff);
        Debug.Log(targetPoint);

        transform.LookAt(targetPoint);

        oldPosition = transform.position;
    }
}