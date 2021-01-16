using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public GameObject universe;
    public GameObject host; // should only be used for initial velocity

    private Rigidbody2D rb;
    private Rigidbody2D hostRb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (host == null)
        {
            return;
        }

        hostRb = host.GetComponent<Rigidbody2D>();

        // Vector2 r = host.transform.position - transform.position;
        // float newSpeed = Mathf.Sqrt(Universe.gravitationalConstant * hostRb.mass / r.magnitude);
        // rb.velocity = Quaternion.Euler(0, 0, -90) * r.normalized * newSpeed;

    }

    public void FixedTick()
    {
        if (host == null)
        {
            return;
        }

        Vector2 force = Vector2.zero;

        Vector2 r = host.gameObject.transform.position - transform.position;
        print(host + " " + host.gameObject + " " + host.gameObject.GetComponent<Rigidbody2D>());
        float gravitationalForce = universe.GetComponent<UniverseMaster>().gravitationalConstant *
        host.gameObject.GetComponent<Rigidbody2D>().mass * rb.mass / Mathf.Pow(r.magnitude, 2);

        force += gravitationalForce * r.normalized;

        rb.AddForce(force);
        print("tick) ");
    }

}