using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCube
{
    public class CosmicCube : MonoBehaviour
    {
        private Rigidbody rb;
        private Renderer rend;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rend = GetComponent<Renderer>();
            rend.material.color = Color.red;
        }

        void Update()
        {
            // Constant rotation on all axes
            transform.Rotate(new Vector3(30, 45, 60) * Time.deltaTime);
        }

        void OnCollisionEnter(Collision collision)
        {
            rend.material.color = Color.green;
        }

        void OnCollisionExit(Collision collision)
        {
            rend.material.color = Color.red;
        }
    }
}
