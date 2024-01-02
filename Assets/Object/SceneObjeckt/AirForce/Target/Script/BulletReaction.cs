using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletReaction : MonoBehaviour
{
    public GameObject explosionEffect;
    private bool hasPlayed = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet") && hasPlayed == false)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            hasPlayed = true;
        }
    }
}
