using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grarvity : MonoBehaviour
{
    [Header("Settings")]
    public float gravity = 9.18f;

    public bool is_grounded = false;

    [Header("References")]
    [SerializeField] Transform world;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!is_grounded)
        {
            Vector3 dir = world.position - transform.position;

            rb.AddForce(dir * gravity * Time.deltaTime);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_grounded = true;
        }
        else
        {
            is_grounded = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_grounded = false;
        }
    }
}
