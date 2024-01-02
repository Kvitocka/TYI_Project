using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PutObjecktInMap : MonoBehaviour
{
private Vector3 MausPositionInMap;


private void Update()
{
        if (Input.GetMouseButtonDown(1)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            Physics.Raycast(ray, out hit);

            if (Physics.Raycast(ray, out hit))
            {

                MausPositionInMap = hit.point;

            }
            else { MausPositionInMap = new Vector3(); }

        }
}

    public void AddTarget(AddPrefabToCanvas addPrefabToCanvas )
    {
        if (MausPositionInMap != new Vector3(0, 0, 0))
        {
            addPrefabToCanvas.AddPrefabToCanvasObject(MausPositionInMap+ new Vector3(0, 20, 0), 0, "Target");
        }
    }
    public void AddTargetToPoint(AddPrefabToCanvas addPrefabToCanvas)
    {
        if (MausPositionInMap != new Vector3(0, 0, 0))
        {
            addPrefabToCanvas.AddPrefabToCanvasObject(MausPositionInMap+new Vector3(0,20,0) ,1, "TargetToPoints");
        }
    }

    public void AddAASystem(AddPrefabToCanvas addPrefabToCanvas)
    {
        if (MausPositionInMap != new Vector3(0, 0, 0))
        {
            addPrefabToCanvas.AddPrefabToCanvasObject(MausPositionInMap, 0, "AntiAirSystem");
        }
    }
    public void AddRacketSystem(AddPrefabToCanvas addPrefabToCanvas)
    {
        if (MausPositionInMap != new Vector3(0, 0, 0))
        {
            addPrefabToCanvas.AddPrefabToCanvasObject(MausPositionInMap, 1, "RacketSystem");
        }
    }

    public void AddRacketRadiusSystem(AddPrefabToCanvas addPrefabToCanvas)
    {
        if (MausPositionInMap != new Vector3(0, 0, 0))
        {
            addPrefabToCanvas.AddPrefabToCanvasObject(MausPositionInMap, 2, "RacketSystem");
        }
    }



}
