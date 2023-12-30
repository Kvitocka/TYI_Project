using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauntHunter : MonoBehaviour
{
    public int caunt = 0;

    public int myCod;
    private void Start()
    {
        myCod = Random.Range(0, 10000000);
    }

    public void addCaunt()
    {
        caunt++;
    }

    public void minusCaunt()
    {
        caunt--;
    }
}