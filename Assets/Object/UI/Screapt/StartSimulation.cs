using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartSimulation : MonoBehaviour
{
    // Start is called before the first frame update
    public static Action TapStart;

    public GameObject BeforeCanvas;

    public GameObject AfterCanvas;

    public void BeginSimulatuon() {
        TapStart?.Invoke();

        Invoke("changeScene", 0.02f);
    }

    private void changeScene() {
        BeforeCanvas.SetActive(false);
        AfterCanvas.SetActive(true);
    }

}
