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
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Apply force
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, gun_mask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Move Cat
                move_dir = (transform.position - hit.point).normalized;
                rb.AddForce(move_dir * gun_force);
                //Roate Cat

                //Shoot bullet
                CatShoot.instance.Shoot((hit.point - transform.position).normalized);
            }
        }
    }
}
