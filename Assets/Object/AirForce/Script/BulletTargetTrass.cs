using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTargetTrass : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();

    void Update()
    {
        points.Add(transform.position);

        if (points.Count > 1000)
        {
            points.RemoveAt(0);
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}
