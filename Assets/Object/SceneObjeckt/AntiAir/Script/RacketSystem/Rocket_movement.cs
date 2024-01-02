using System.Collections;
using UnityEngine;

public class Rocket_movement : MonoBehaviour
{
    public GameObject target;

    private Rigidbody rb;

    public float speed;

    public float acceleration;

    public float maxRotationSpeed;

    private bool goToTarget = false;

    public float distance;

    public bool IsRadiu=false;

    public void Shot()
    {
        transform.LookAt(transform.position+new Vector3(0,1,0));

        rb = GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(0, 1, 0) * rb.mass * 500);

        StartCoroutine(Stop(3f));
    }

    private void Update()
    {
        if (goToTarget && target!=null)
        {
            Vector3 targetDirection = target.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, maxRotationSpeed * Time.deltaTime);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            speed += acceleration * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, target.transform.position)< distance && target != null) {

            Destroy(target);
            Destroy(gameObject);

            if (IsRadiu) {

                Collider[] colliders = Physics.OverlapSphere(transform.position, distance);

                foreach (Collider collider in colliders)
                {

                    if (collider.gameObject.CompareTag("Target"))
                    {
                        Destroy(collider.gameObject);
                    }

                    
                }

            }
            
        }

    }

    private IEnumerator Stop(float delay)
    {
        yield return new WaitForSeconds(delay);

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.useGravity = false;

        goToTarget = true;
    }
}
