using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGunMovement : MonoBehaviour
{
    // public vars
    public float gun_force = 50;
    public LayerMask gun_mask;
    public LayerMask grounded_mask;

    // System vars
    Vector3 move_dir;

    bool grounded;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Grounded check
        Ray ground_ray = new Ray(transform.position, -transform.up);
        RaycastHit ground_hit;
        if (Physics.Raycast(ground_ray, out ground_hit, 1 + .1f, grounded_mask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    void FixedUpdate()
    {
        // Apply force
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, gun_mask))
            {
                Debug.Log(hit.transform.name);
                move_dir = (transform.position - hit.point).normalized;
                rb.AddForce(move_dir * gun_force);
            }
        }
    }
}
