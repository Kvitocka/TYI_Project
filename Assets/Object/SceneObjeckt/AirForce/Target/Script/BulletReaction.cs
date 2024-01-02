using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletReaction : MonoBehaviour
{
    public GameObject explosionEffect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
