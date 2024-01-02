using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPosition : MonoBehaviour
{
   public void SetXPosition(String s){
        if(s==""){s="0";}
         transform.position = new Vector3(float.Parse(s), transform.position.y, transform.position.z);
    }
    public void SetYPosition(String s){
         if(s==""){s="0";}
        transform.position = new Vector3(transform.position.x,float.Parse(s), transform.position.z);
    }
    public void SetZPosition(String s){
         if(s==""){s="0";}
         transform.position = new Vector3(transform.position.x,transform.position.y, float.Parse(s));
    }
}
