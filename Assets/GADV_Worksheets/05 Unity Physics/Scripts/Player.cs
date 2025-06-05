using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;

    // Your variables used for moving the player
    public float speed = 6.0f;
    public float rotateSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private int jumps;

    // Code to set the radius and force of the explosion
    public float radius = 5.0f;
    public float power = 10000.0F;

    public float kickStrength = 20.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = false; // See comment about this!
        
    }

    private void Update()
    {
        CheckLineOfSight();
    }

    void CheckExplosion()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, transform.position, radius, 1.0f);
                }
            }
        }
    }

    void Kick()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position + transform.forward * 20f, 20f);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddForce(transform.forward * kickStrength);
                }
            }
        }
    }

    void CheckLineOfSight()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        RaycastHit hit;

        foreach (GameObject enemy in enemies)
        {
            Vector3 vec = enemy.transform.position - transform.position;
            Debug.DrawRay(transform.position, vec * 30f, Color.red);

            if (Physics.Raycast(transform.position, vec, out hit, 300f))
            {
                Renderer enemyRenderer = enemy.GetComponent<Renderer>();

                if (hit.collider.gameObject.CompareTag("Enemy") == enemy)
                {
                    enemyRenderer.material.color = Color.green;
                }
                else
                {
                    enemyRenderer.material.color = Color.red;
                }
            }
        }
    }


    void FixedUpdate()
    {
        CheckExplosion();

        Kick();

        // Your code to move the player 
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButtonDown("Fire1") && jumps <1)
            {
                moveDirection.y = jumpSpeed;
                jumps++;

            }
        }
        else
        {
            moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;

        }

        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
