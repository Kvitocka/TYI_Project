using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route_movement : MonoBehaviour
{
    public List<Vector3> pointList = new List<Vector3>();
    public float speed = 1.0f;
    public float acceleration = 0.0f;
    public int count = 0;
    private Vector3 movement_direction;

    // Start is called before the first frame update
    void Start()
    {

        // Add points to the list
        pointList.Add(new Vector3(10.0f, 5.0f, 7.0f));
        pointList.Add(new Vector3(4.0f, 5.0f, 6.0f));
        pointList.Add(new Vector3(-2.0f, 0.0f, 8.0f));
        Debug.Log(transform.position);
        movement_direction = pointList[0] - transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement_direction = pointList[count] - transform.position;
        if(movement_direction.magnitude > 0.1f)
        {
            movement_direction.Normalize();
            transform.Translate(movement_direction * speed / 50);
            speed += acceleration/50;
        }
        else
        {
            count += 1;
            movement_direction = pointList[count] - transform.position;
        }
    }
}
