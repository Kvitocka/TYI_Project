using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTime : MonoBehaviour
{
    public void ControlTimeVithData(float speedTime){
        Time.timeScale = speedTime;
        Time.fixedDeltaTime = 0.02f * speedTime;
    }
}
