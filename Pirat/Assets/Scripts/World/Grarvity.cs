using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody))]
public class Grarvity : MonoBehaviour
{
    [Header("Settings")]
    public float gravity = 9.18f;

    [Header("References")]
    [SerializeField] Transform world;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        world = GameObject.FindGameObjectWithTag("Ground").transform;
    }

    void FixedUpdate()
    {
        Vector3 dir = (world.position - transform.position).normalized;
        Vector3 cat_up = -transform.up;

        transform.rotation = Quaternion.FromToRotation(cat_up, dir) * transform.rotation;
        rb.AddForce(dir * gravity);
    }
}
