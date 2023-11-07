using UnityEngine;

public class BarrelRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] public Transform target;

	private float currentRotation = 0.0f;

	void Update()
	{
		RotateToTarget();
	}

    public void RotateToTarget()
    {
            Vector3 targetDirection = target.position - transform.position;
            float targetRotation = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            float step = rotationSpeed * Time.deltaTime;
            currentRotation = Mathf.MoveTowardsAngle(currentRotation, targetRotation, step);
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }
}