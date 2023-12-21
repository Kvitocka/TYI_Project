using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PutObjecktInMap : MonoBehaviour
{
private Vector3 MausPositionInMap;

private void Update()
{
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        Physics.Raycast(ray,out hit);

        if(Physics.Raycast(ray,out hit)){
        
            MausPositionInMap = hit.point;

        }
        else{MausPositionInMap=new Vector3();}
   
}

public void MakeObjecktInPosition(AddPrefabToCanvas addPrefabToCanvas){
    if(MausPositionInMap!= new Vector3(0,0,0)){
    addPrefabToCanvas.AddPrefabToCanvasObject(MausPositionInMap);
    }
}

}
