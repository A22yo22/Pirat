using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CatGunMovement : MonoBehaviour
{
    // public vars
    public float gun_force = 50;
    public LayerMask gun_mask;
    public LayerMask grounded_mask;

    // System vars
    public Transform cat_gfx;
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
                //Roate Cat
                Look_At_Y(cat_gfx, hit.point, transform.up);

                //Move Cat
                move_dir = (transform.position - hit.point).normalized;
                rb.AddForce(move_dir * gun_force);

                //Shoot bullet
                CatShoot.instance.Shoot();
            }
        }
    }

    public void Look_At_Y(Transform cat, Vector3 target_position, Vector3 up_direction)
    {
        Quaternion y_rotation = Quaternion.LookRotation((target_position - cat.position).normalized, up_direction);
        cat.rotation = y_rotation;
    }
}