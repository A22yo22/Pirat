using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public static CatMovement instance;

    // public vars
    public bool is_looked;

    public float mouse_sensitivity_x = 1;
    public float walk_speed;
    public float jump_force = 220;
    public float knockback_force = 600;
    public LayerMask grounded_mask;

    // System vars
    public bool grounded;
    public Vector3 move_amount;
    Vector3 smooth_move_velocity;
    Rigidbody rb;
    public Animator cat_anim;

    void Awake()
    {
        if(instance == null) { instance = this; }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (CatShoot.instance.gun_cooldown_timer <= 0 && ScoreManager.instance.is_ingame)
        {
            // Look rotation:
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouse_sensitivity_x);

            // Calculate movement:
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
            Vector3 targetMoveAmount = moveDir * walk_speed;
            move_amount = Vector3.SmoothDamp(move_amount, targetMoveAmount, ref smooth_move_velocity, .15f);

            if (inputX > 0 || inputY > 0)
            {
                cat_anim.SetTrigger("Walk");
            }
            else
            {
                cat_anim.SetTrigger("Idle");
            }

            // Jump
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(transform.up * jump_force);
            }
        }

        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, 2 + .1f, grounded_mask))
        {
            grounded = true;
        }
        else
        {
            //grounded = false;
        }
    }

    void FixedUpdate()
    {
        if (CatShoot.instance.gun_cooldown_timer <= 0 && ScoreManager.instance.is_ingame)
        {
            // Apply movement to rigidbody
            Vector3 localMove = transform.TransformDirection(move_amount) * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + localMove);
        }
    }

    public void Apply_Knockback()
    {
        Vector3 force_dir = new Vector3(-transform.forward.x, -transform.forward.y * 1.5f, -transform.forward.z);
        rb.AddForce(force_dir * knockback_force);
    }
}
