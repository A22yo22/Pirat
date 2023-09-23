using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatShoot : MonoBehaviour
{
    public static CatShoot instance;

    // Public vars
    public float bullet_speed = 50;

    // Gun
    public float gun_cooldown = 0.5f;
    public float gun_cooldown_timer = 0.5f;

    public float bullet_destroy_time = 1f;

    // System vars
    public GameObject bullet;
    public Transform bullet_start_pos;

    private void Awake()
    {
        if(instance == null) { instance= this; }
    }

    private void Update()
    {
        // Timer Logic
        if (gun_cooldown_timer > 0)
        {
            gun_cooldown_timer -= Time.deltaTime;
        }

        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            //Shoot bullet
            if (gun_cooldown_timer <= 0)
            {
                Shoot();
                gun_cooldown_timer = gun_cooldown;
            }
        }
    }

    public void Shoot()
    {
        GameObject fired_bullet = Instantiate(bullet, bullet_start_pos.position, Quaternion.Euler(0, 0, 0));
        Rigidbody rb = fired_bullet.GetComponent<Rigidbody>();
        rb.AddForce(bullet_start_pos.forward * bullet_speed);

        Destroy(fired_bullet, bullet_destroy_time);
    }
}
