using System;
using UnityEngine;

public class AddPrefabToCanvas : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public Transform Lokaction;
    public String ChildName;
    public void AddPrefabToCanvasObject()
    {
            GameObject obj = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
            obj.transform.Find(ChildName).SetParent(Lokaction);
            obj.transform.SetParent(transform);
    }

    public void AddPrefabToCanvasObject(Vector3 SpawnPosition)
    {
            GameObject obj = Instantiate(prefabToInstantiate, SpawnPosition, Quaternion.identity);
            obj.transform.Find(ChildName).position=SpawnPosition;
            obj.transform.Find(ChildName).SetParent(Lokaction);
            obj.transform.SetParent(transform);
            
            
    }
}
