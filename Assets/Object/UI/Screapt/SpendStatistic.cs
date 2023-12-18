using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpendStatistic : MonoBehaviour
{
    public TMP_Text text;
    private int DataNow=0;

    private void OnEnable()
    {
        bullet_class.OnTach+=RemekeData;
    }

    private void OnDisable()
    {
        bullet_class.OnTach-=RemekeData;
    }

    public void RemekeData (){
        DataNow+=1;
        text.text="Витрачено снарядів:"+DataNow;
    }
}
