using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class See : MonoBehaviour
{
    public  bool CanISee(Collider collider)
    {
        transform.LookAt(collider.gameObject.transform.position);

        Ray ray = new Ray (transform.position,transform.forward);

        RaycastHit hit;

        Physics.Raycast(ray,out hit);
        
        return collider==hit.collider;

    }
}
