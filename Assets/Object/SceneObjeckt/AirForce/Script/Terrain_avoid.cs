using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public SphereCollider sphereCollider;
    private Rigidbody rb;
    public List<GameObject> collideObjects;


    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<collideObjects.Count;i++)
        {
            float impulseDistance = Vector3.Distance(transform.position, collideObjects[i].transform.position);         
            float force = sphereCollider.radius/impulseDistance/5;

            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;

            rb = GetComponent<Rigidbody>();
            if (Physics.Raycast(ray, out hit, sphereCollider.radius)){
                Vector3 hitPoint = hit.point;
                Vector3 impulseVector = transform.position - hitPoint;
                rb.AddForce(impulseVector * force, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Terrain"))
        {
            collideObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Terrain"))
        {
            collideObjects.Remove(other.gameObject);
        } 
    }
}
