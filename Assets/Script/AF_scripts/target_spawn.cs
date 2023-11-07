using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_spawn : MonoBehaviour
{
    public GameObject targetPrefab; // Prefab of the flying target object
    public float movementSpeed = 5f; // Speed of movement along the X-axis

    private GameObject targetObject; // Reference to the spawned target object
    // Start is called before the first frame update
    void Start()
    {
        // Spawn the flying target object at the specified position
        SpawnTargetObject(new Vector3(0f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            // Move the target object along the X-axis
            targetObject.transform.Translate(Vector3.right * (movementSpeed * Time.deltaTime));
        }
    }
    // Spawn the target object at the specified position
    void SpawnTargetObject(Vector3 spawnPosition)
    {
        if (targetPrefab != null)
        {
            targetObject = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Target prefab is not assigned!");
        }
    }
}
