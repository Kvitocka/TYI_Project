using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_spawn : MonoBehaviour
{
 public void Update()
 {
    transform.Translate(Vector3.forward * 10 * Time.deltaTime);
 }
    
}
