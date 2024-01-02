using System.Xml.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class linear_movement : MonoBehaviour
{
    public Vector3 target_direction = new Vector3(0.0f, 0.0f, 0.0f);
    public float notCorectSpeed=0f;
    public float notCorectAcceleration=0f;
    private float target_speed = 0.0f;
    private float target_acceleration = 0.0f;
    private bool wosStart = false;

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
        wosStart = true;

        if (target_direction != new Vector3(0f, 0f, 0f)) {

            rb = GetComponent<Rigidbody>();

            MakeCorrectParameters();

            if(AirResistance == null){
                rb.AddForce(target_direction * target_speed, ForceMode.VelocityChange);
            }
            else{
                rb.AddForce(target_direction * target_speed - AirResistance.CalkulateAirResistance(target_direction, target_speed), ForceMode.VelocityChange);
            }
            rb.AddForce(target_direction * target_acceleration, ForceMode.Acceleration);
        }
    }

    private void Update()
    {
        if (wosStart) { 
            transform.LookAt(target_direction+transform.position);
        }
    }

    private void MakeCorrectParameters()
    {
        //float b = target_speed/MathF.Sqrt(target_direction.x*target_direction.x+target_direction.y*target_direction.y+target_direction.z*target_direction.z);
        //target_speed=b;

        //target_acceleration =0;

        target_speed = notCorectAcceleration;
        target_acceleration = notCorectSpeed;
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
