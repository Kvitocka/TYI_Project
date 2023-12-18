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
}
