using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirResistance : MonoBehaviour
{
    // Start is called before the first frame update
    public bool UseAirResistance = false ;
    public float radius=0f;
    public float DynamicViscosityOfLiquid=0.0000163f;

    public Vector3 CalkulateAirResistance (Vector3 target_direction,float target_speed){
        return target_direction*18.85f*DynamicViscosityOfLiquid*radius*target_speed;
    }

    private void Start()
    {
        if(UseAirResistance==false){
            DynamicViscosityOfLiquid=0;
        }
    }
}
