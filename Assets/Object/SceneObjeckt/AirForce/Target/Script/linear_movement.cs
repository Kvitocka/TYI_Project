using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class linear_movement : MonoBehaviour
{
    public Vector3 target_direction = new Vector3(0.0f, 0.0f, 0.0f);
    private float notCorectSpeed=0f;
    private float notCorectAcceleration=0f;
    public float target_speed = 0.0f;
    public float target_acceleration = 0.0f;

    public AirResistance AirResistance;

    private Rigidbody rb;

    public void OnEnable()
    {
        StartSimulation.TapStart += StartGame;
    }

    public void OnDisable()
    {
        StartSimulation.TapStart -= StartGame;
    }

    private void StartGame ()
    {
        if (target_direction != new Vector3(0f, 0f, 0f)) {

            rb = GetComponent<Rigidbody>();

            MakeCorrectParameters();
            
            rb.AddForce(target_direction * target_speed - AirResistance.CalkulateAirResistance(target_direction, target_speed), ForceMode.VelocityChange);
            Debug.Log(target_acceleration);
            rb.AddForce(target_direction * target_acceleration, ForceMode.Acceleration);

        }
    }

    private void MakeCorrectParameters()
    {
       target_speed=notCorectSpeed/Vector3.Distance(new Vector3(0f,0f,0f), target_direction);
       target_acceleration = notCorectAcceleration / Vector3.Distance(new Vector3(0f, 0f, 0f), target_direction);
    }

    public void SetSpeed(String s){
        if(s==""){s="0";}
        notCorectSpeed = float.Parse(s);
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
        notCorectAcceleration = float.Parse(s);
    }

}
