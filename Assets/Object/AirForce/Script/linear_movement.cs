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

}
