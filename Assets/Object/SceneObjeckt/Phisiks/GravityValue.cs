using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityValue : MonoBehaviour
{
     public void SetGravity(String s){
        if(s==""){s="0";}
        Physics.gravity = new Vector3(0, float.Parse(s), 0);
    }
}
