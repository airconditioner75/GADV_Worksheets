using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orb
{
    public class Orb : MonoBehaviour
    {
        Rigidbody rb;
        public float force = 50.0f;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
            }
        }


    }
}
