using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BhGravity : MonoBehaviour
{
    public Vector3 velocity;
    public float initialSpeed = 1f;
    public BhGravity otherBh;
    
    public float mass = 1;
    public float massScale = 1000f;
    public static float distanceScale = 1000;

    Vector3 a;

    private void Start()
    {
        velocity = transform.forward * initialSpeed;

        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        mass *= massScale;

        while (true)
        {
            Vector3 gravDir = (otherBh.transform.position - transform.position) * distanceScale;

            float f = Mathf.Pow(6.674f, -11) * mass * otherBh.mass / Mathf.Pow(gravDir.magnitude, 2);

            a = f / mass * gravDir.normalized;

            Vector3 gravV = a / Time.deltaTime;

            transform.position += (velocity + gravV) * Time.deltaTime;

            Vector3 apparentV = velocity + gravV;

            velocity = apparentV;

            yield return null;
        }
        
        // * (otherBh.position - transform.position) 
    }
}
