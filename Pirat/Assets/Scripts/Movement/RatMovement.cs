using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rat_State
{
    Idle,
    Walk,
    Cat_Spotted
}

public class RatMovement : MonoBehaviour
{
    public float rat_move_speed = 2f;
    public float to_cat_move_speed = 3f;

    public Rat_State rat_state = Rat_State.Idle;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 localMove = Vector3.zero;

        switch (rat_state)
        {
            case Rat_State.Idle:
                break;
            case Rat_State.Walk:

                localMove = transform.TransformDirection(transform.forward) * rat_move_speed * Time.fixedDeltaTime;
                rb.MovePosition(rb.position + localMove);

                break;
            case Rat_State.Cat_Spotted:

                localMove = transform.TransformDirection((transform.position - CatMovement.instance.transform.position).normalized) * to_cat_move_speed * Time.fixedDeltaTime;
                rb.MovePosition(rb.position + localMove);

                break;
        }
    }
}
