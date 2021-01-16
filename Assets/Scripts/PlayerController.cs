using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 1)]
    public float movementForce;
    [Range(0, 100)]
    public float rotationTorque;
    public float maxAngularVelocity;
    public float maxVelocity;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float inputRotate = Input.GetAxis("Horizontal");
        float inputRelativeY = Input.GetAxis("Vertical");

        rb.AddTorque(-inputRotate * rotationTorque, ForceMode2D.Impulse);
        if (rb.angularVelocity > maxAngularVelocity)
        {
            rb.angularVelocity = maxAngularVelocity;
        }
        else if (rb.angularVelocity < -maxAngularVelocity)
        {
            rb.angularVelocity = -maxAngularVelocity;
        }

        rb.AddRelativeForce(new Vector2(0, inputRelativeY) * movementForce, ForceMode2D.Impulse);
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    void Reset()
    {
        transform.SetPositionAndRotation(Vector3.zero, new Quaternion(0, 0, 0, 0));
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
    }
}
