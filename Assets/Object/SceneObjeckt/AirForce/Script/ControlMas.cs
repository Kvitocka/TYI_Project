using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ControlMas : MonoBehaviour
{
     public float MassCorps=10f;
     public float MassOil=10f;

     public float SpendOilForSecond = 0 ;

     float SpendOilForframe;

     public Rigidbody rb;

    private bool WosStart=false;

    private void Start()
    {
    rb = GetComponent<Rigidbody>();   
    }

    private void FixedUpdate()
    {
        if ( WosStart)
        {
            SpendOilForframe = SpendOilForSecond / 50;
            if (MassOil > 0)
            {
                if (MassOil > SpendOilForframe)
                {
                    MassOil -= SpendOilForframe;
                    rb.mass = MassCorps + MassOil;
                }
                if (MassOil < SpendOilForframe)
                {
                    MassOil = 0;
                    rb.mass = MassCorps + MassOil;
                }
            }
        }
    }


    public void OnEnable()
    {
        StartSimulation.TapStart += StartGame;
    }

    public void OnDisable()
    {
        StartSimulation.TapStart -= StartGame;
    }

    private void StartGame()
    {
        WosStart = true;
    }

    public void SetMasOil(String s){
        if(s==""){s="0";}
        MassOil=float.Parse(s);
        }
        public void SetSpendOil(String s){
        if(s==""){s="0";}
        SpendOilForSecond=float.Parse(s);
        }
        public void SetMasСorps(String s){
        if(s==""){s="0";}
        MassCorps=float.Parse(s);
        }
}
