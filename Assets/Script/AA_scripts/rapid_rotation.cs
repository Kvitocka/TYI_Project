using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float rotationAngle = 60f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, rotationAngle, 0);
    }
}
