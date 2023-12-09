using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linear_movement : MonoBehaviour
{
    public Vector3 target_direction = new Vector3(1.0f, 0.0f, 0.0f);
    public float target_speed = 5.0f;
    public float target_acceleration = 5.0f;

    public AirResistance AirResistance;
    void FixedUpdate()
    { //target_direction*18.85f*DynamicViscosityOfLiquid*radius calculate Air resistance
        transform.Translate((target_direction * target_speed / 50)-AirResistance.CalkulateAirResistance(target_direction,target_speed));
        target_speed += target_acceleration/50;
    }

    public void SetSpeed(String s){
        if(s==""){s="0";}
        target_speed=float.Parse(s);
        }
    public void SetSpeedX(String s){
        if(s==""){s="0";}
        target_direction.x = float.Parse(s);
    }
    public void SetSpeedY(String s){
        if(s==""){s="0";}
        target_direction.y = float.Parse(s);
    }
    public void SetSpeedZ(String s){
        if(s==""){s="0";}
        target_direction.z = float.Parse(s);
    }
    public void SetAcceleration(String s){
        if(s==""){s="0";}
        target_acceleration=float.Parse(s);
        }

}
