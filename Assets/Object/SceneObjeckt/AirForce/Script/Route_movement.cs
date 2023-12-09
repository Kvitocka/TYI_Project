using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route_movement : MonoBehaviour
{
    public List<Vector3> pointList = new List<Vector3>();
    public float speed = 1.0f;
    public float acceleration = 0.0f;
    public int count = 0;
    public Vector3 AddNewPoint=new Vector3(0,0,0);
    private Vector3 movement_direction=new Vector3(0,0,0);

    private bool pointIs = false;
    
    public GameObject PointPrefab;

    GameObject bullet;



    // Start is called before the first frame update
    void SStart()
    {

        // Add points to the list
        pointList.Add(new Vector3(10.0f, 25.0f, 25.0f));
        pointList.Add(new Vector3(100.0f, 25.0f, 25.0f));
        Debug.Log(transform.position);
        movement_direction = pointList[0] - transform.position;

    }

    void SFixedUpdate()
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

    public void visualRouteMoveCordX (String s){
        if(s==""){s="0";}
        AddNewPoint.x=float.Parse(s);
        pointIsOrNor();
    }
    public void visualRouteMoveCordY (String s){
        if(s==""){s="0";}
        AddNewPoint.y=float.Parse(s);
        pointIsOrNor();
    }
    public void visualRouteMoveCordZ (String s){
        if(s==""){s="0";}
        AddNewPoint.x=float.Parse(s);
        pointIsOrNor();
    }
    public void addPoins (){
        pointList.Add(AddNewPoint);

        bullet = Instantiate(PointPrefab, AddNewPoint,new Quaternion());
          
    }

    public void pointIsOrNor (){

          if(!pointIs){
            bullet = Instantiate(PointPrefab, AddNewPoint,new Quaternion());
            pointIs=true;
            }
            else{
                bullet.transform.position=AddNewPoint;
            }
            
    }



}
