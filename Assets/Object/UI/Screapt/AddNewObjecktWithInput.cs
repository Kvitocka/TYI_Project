using System;
using System.Collections.Generic;
using UnityEngine;

public class AddPrefabToCanvas : MonoBehaviour
{
    public List <GameObject> prefabToInstantiate;
    public Transform Lokaction;
    
    public void AddPrefabToCanvasObject(Vector3 SpawnPosition , int i , String ChildName)
    {
            GameObject obj = Instantiate(prefabToInstantiate[i], SpawnPosition, Quaternion.identity);
            obj.transform.Find(ChildName).position=SpawnPosition;
            obj.transform.Find(ChildName).SetParent(Lokaction);
            obj.transform.SetParent(transform);
            
            
    }
}
