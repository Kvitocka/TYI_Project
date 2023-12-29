using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TransformObjeckt : MonoBehaviour
{

    public void SetPositionX(String s){
        if(s==""){s="0";}
        transform.position = new Vector3(float.Parse(s), transform.position.y, transform.position.z);
    }
    public void SetPositionY(String s){
        if(s==""){s="0";}
       transform.position = new Vector3(transform.position.x, float.Parse(s), transform.position.z);
    }
    public void SetPositionZ(String s){
        if(s==""){s="0";}
        transform.position = new Vector3( transform.position.x, transform.position.y, float.Parse(s));
    }

     public void SetScaleX(String s)
    {
        if(s==""){s="1";}
        transform.localScale = new Vector3(float.Parse(s), transform.localScale.y, transform.localScale.z);
    }
    public void SetScaleY(String s){
        if(s==""){s="1";}
       transform.localScale = new Vector3( transform.localScale.x, float.Parse(s), transform.localScale.z);
    }
    public void SetScaleZ(String s){
        if(s==""){s="1";}
       transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, float.Parse(s));
    }
}
