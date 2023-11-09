using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class controlGravyt : MonoBehaviour
{
     public float GravityValue;
     public float MassСorps=10f;
     public float MassOil=10f;

     public float SpendOilForSecond = 0 ;

     float SpendOilForframe;

     public Rigidbody rb;
    void Awake()
    {
        
    }

    private void Start()
    {
    rb = GetComponent<Rigidbody>();   
    }
    private void FixedUpdate()
    {
        Physics.gravity = new Vector3(0, GravityValue, 0);
        SpendOilForframe = SpendOilForSecond/50;
        if  (MassOil>0){
            if(MassOil>SpendOilForframe){MassOil-=SpendOilForframe;}
            if(MassOil<SpendOilForframe){MassOil=0;}
        }
        rb.mass = MassСorps+MassOil;
    }
}
