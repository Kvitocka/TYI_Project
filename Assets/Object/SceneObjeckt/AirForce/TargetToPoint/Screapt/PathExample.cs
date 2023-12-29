using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathExample : MonoBehaviour
{
    List<Vector3> pointList = new List<Vector3>();

    Vector3 AddNewPoint = new Vector3(0, 0, 0);

    Vector3[] points; 

    public GameObject PointPrefab;

    public float speed=1;

    private GameObject bullet;
    float value;
    private bool pointIs = false;
    private bool WosStart = false;

    public void OnEnable()
    {
        StartSimulation.TapStart += StartGame;
    }

    public void OnDisable()
    {
        StartSimulation.TapStart -= StartGame;
    }

    private void Start()
    {
        pointList.Add(transform.position);
    }
    private void StartGame()
    {
        points = remakeListToMas(pointList);

        WosStart =true;
    }

    void Update()
    {
        if (WosStart) {

            if (value < 1)
            {
                value += speed * Time.deltaTime / 10;
                iTween.PutOnPath(gameObject.transform, points, value);
            }
            else { Destroy(gameObject); }

            
        }
    }
    public void SetSpeed(String s)
    {
        if (s == "") { s = "0"; }
        speed = float.Parse(s);
    }
    public void visualRouteMoveCordX(String s)
    {
        if (s == "") { s = "0"; }
        AddNewPoint.x = float.Parse(s);
        pointIsOrNor();
    }
    public void visualRouteMoveCordY(String s)
    {
        if (s == "") { s = "0"; }
        AddNewPoint.y = float.Parse(s);
        pointIsOrNor();
    }
    public void visualRouteMoveCordZ(String s)
    {
        if (s == "") { s = "0"; }
        AddNewPoint.z = float.Parse(s);
        pointIsOrNor();
    }
    public void addPoins()
    {
        pointList.Add(AddNewPoint);

        bullet = Instantiate(PointPrefab, AddNewPoint, new Quaternion());
    }

    public void pointIsOrNor()
    {
        if (!pointIs){
            bullet = Instantiate(PointPrefab, AddNewPoint, new Quaternion());
            pointIs = true;
        }
        else
        {bullet.transform.position = AddNewPoint;}
    }

    Vector3[] remakeListToMas(List<Vector3> points)
    {
        Vector3[] mas = new Vector3[points.Count];
        for (int i = 0; i < points.Count; i++)
        {
            mas[i] = points[i];
        }
        return mas;
    }
}
