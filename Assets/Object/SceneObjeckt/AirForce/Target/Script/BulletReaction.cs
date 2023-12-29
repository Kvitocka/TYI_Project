using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletReaction : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}
