using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletReaction : MonoBehaviour
{
    public Collider collider;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}
