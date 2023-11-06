using UnityEngine;

public class BarrelRotate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform barrel;
    [SerializeField] private float barrelSpeed;
    [SerializeField] private GameObject TargetObject;

	Quaternion barrelRotation(Vector3 Target)
	{
		Target.z = Camera.main.transform.position.z;
		Vector3 direction = Camera.main.ScreenToWorldPoint(Target) - transform.position;
		float angle  = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		return Quaternion.AngleAxis(angle, Vector3.forward);
	}
	

	void Update()
	{
		barrel.rotation = Quaternion.Lerp(barrel.rotation, barrelRotation(TargetObject.transform.position), barrelSpeed * Time.deltaTime);
	}

}
