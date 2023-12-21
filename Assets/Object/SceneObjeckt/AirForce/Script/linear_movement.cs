using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class linear_movement : MonoBehaviour
{
    public Vector3 target_direction = new Vector3(1.0f, 0.0f, 0.0f);
    private float notCorectSpeed=25f;
    private float notCorectacceleration=25f;
    public float target_speed = 5.0f;
    public float target_acceleration = 5.0f;

    public AirResistance AirResistance;

    private Rigidbody rb;

    private void Start()
    {
        MakeCorrectSpeed();
        MakeCorrectAcceleration();

        rb= GetComponent<Rigidbody>();
         }
    void FixedUpdate()
    { //target_direction*18.85f*DynamicViscosityOfLiquid*radius calculate Air resistance
        transform.Translate((target_direction * target_speed / 50)-AirResistance.CalkulateAirResistance(target_direction,target_speed));
        target_speed += target_acceleration/50;
    }

    private void MakeCorrectSpeed()
    {
       // if(target_direction == new Vector3 (0f,0f,0f)){target_speed=0;}
       // else{target_speed=(float)(notCorectSpeed/(Math.Sqrt(target_direction.x*target_direction.x+target_direction.y*target_direction.y+target_direction.z*target_direction.z)));}
    }

    private void MakeCorrectAcceleration()
    {
      //  if(target_direction == new Vector3 (0f,0f,0f)){target_acceleration=0;}
      //  {target_acceleration=(float)(notCorectacceleration/(Math.Sqrt(target_direction.x*target_direction.x+target_direction.y*target_direction.y+target_direction.z*target_direction.z)));}
    }

     public void AddSpeed(){
       rb.AddForce(target_direction*target_speed-AirResistance.CalkulateAirResistance(target_direction,target_speed),ForceMode.VelocityChange);
        }

         public void AddAseleration(){
        rb.AddForce(target_direction*target_acceleration,ForceMode.Acceleration);
   }

    public void SetSpeed(String s){
        if(s==""){s="0";}
        target_speed=float.Parse(s);
        
        AddSpeed();
        }
    public void SetSpeedX(String s){
        if(s==""){s="0";}
        target_direction.x = float.Parse(s);
        
        AddAseleration();
        AddSpeed();
    }
    public void SetSpeedY(String s){
        if(s==""){s="0";}
        target_direction.y = float.Parse(s);
        
        AddAseleration();
        AddSpeed();
    }
    public void SetSpeedZ(String s){
        if(s==""){s="0";}
        target_direction.z = float.Parse(s);
        
        AddAseleration();
        AddSpeed();
    }
    public void SetAcceleration(String s){
        if(s==""){s="0";}
        target_acceleration=float.Parse(s);
        
        AddAseleration();
    }

}
