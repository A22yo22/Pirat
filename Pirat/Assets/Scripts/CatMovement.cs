using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    // public vars
    public float mouse_sensitivity_x = 1;
    public float walk_speed;
    public float jump_force = 220;
    public LayerMask grounded_mask;

    // System vars
    bool grounded;
    Vector3 move_amount;
    Vector3 smooth_move_velocity;
    Rigidbody rb;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Look rotation:
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouse_sensitivity_x);

        // Calculate movement:
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walk_speed;
        move_amount = Vector3.SmoothDamp(move_amount, targetMoveAmount, ref smooth_move_velocity, .15f);

        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb.AddForce(transform.up * jump_force);
            }
        }

        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, 1 + .1f, grounded_mask))
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
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(move_amount) * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + localMove);
    }
}
