using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_spawn : MonoBehaviour
{
    public GameObject targetPrefab; // Prefab of the flying target object
    public float movementSpeed = 50f; // Speed of movement along the X-axis
    private GameObject targetObject; // Reference to the spawned target object

    void Start()
    {
        // Spawn the flying target object at the specified position
        SpawnBullet();
    }

    void Update()
    {
    }

    // Spawn the target object at the specified position
    void SpawnBullet(Vector3 spawnPosition)
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