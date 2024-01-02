using System.Collections;
using UnityEngine;

public class Rocket_movement : MonoBehaviour
{
    public GameObject target;

    private Rigidbody rb;

    public float speed;

    public float acceleration;

    private bool goToTarget = false;

    public void Shot()
    {
        transform.LookAt(transform.position+new Vector3(0,1,0));

        rb = GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(0, 1, 0) * rb.mass * 500);

        StartCoroutine(Stop(3f));
    }

    private void Update()
    {
        if (goToTarget)
        {
            transform.LookAt(target.transform.position);

            Vector3 direction = (target.transform.position - transform.position).normalized;

            Vector3 newPosition = transform.position + direction * speed*Time.deltaTime;

            transform.position = newPosition;

            speed += acceleration * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, target.transform.position)<0.5) {
            Debug.Log("ціль знизено");

            Destroy(target);
            Destroy(gameObject);
            
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
