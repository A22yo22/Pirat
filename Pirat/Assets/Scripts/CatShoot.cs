using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatShoot : MonoBehaviour
{
    public static CatShoot instance;

    // Public vars
    public float bullet_speed = 50;

    // System vars
    public GameObject bullet;
    public Transform bullet_start_pos;

    private void Awake()
    {
        if(instance == null) { instance= this; }
    }

    public void Shoot(Vector3 shot_dir)
    {
        GameObject fired_bullet = Instantiate(bullet, bullet_start_pos.position, Quaternion.Euler(0, 0, 0));
        Rigidbody rb = fired_bullet.GetComponent<Rigidbody>();
        rb.AddForce(shot_dir * bullet_speed);
    }
}
