using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    Rigidbody rb;
    public float force = 50.0f;
    public float torqueAmount = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }

        
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
        }

        
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector3.back * force, ForceMode.Impulse);
        }

        
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(Vector3.right * force, ForceMode.Impulse);
        }

        
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector3.left * force, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rb.AddTorque(Vector3.up * torqueAmount, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.AddTorque(Vector3.down * torqueAmount, ForceMode.Impulse);
        }
    }
}
