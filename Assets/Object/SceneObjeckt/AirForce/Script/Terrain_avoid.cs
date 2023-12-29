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

            rb = GetComponent<Rigidbody>();

            Vector3 impulseVector = transform.position - collideObjects[i].transform.position;

            rb.AddForce(impulseVector * force, ForceMode.Impulse);
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
