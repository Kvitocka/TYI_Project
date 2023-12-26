using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityValue : MonoBehaviour
{
    private Vector3 gravity = Vector3.zero;
    private void Start()
    {
        Physics.gravity = Vector3.zero;
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
        Physics.gravity = gravity;
    }

        public void SetGravity(String s){
        if(s==""){s="0";}
        gravity = new Vector3(0, float.Parse(s), 0);
    }
}
