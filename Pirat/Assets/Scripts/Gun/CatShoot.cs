using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CatShoot : MonoBehaviour
{
    public static CatShoot instance;

    // Public vars
    public float bullet_speed = 50;
    public float shake_timer;

    // Gun
    public float gun_cooldown = 0.5f;
    public float gun_cooldown_timer = 0.5f;

    public float bullet_destroy_time = 1f;

    // System vars
    public GameObject bullet;
    public Transform bullet_start_pos;
    public CinemachineVirtualCamera cam;
    public Animator cat_anim;

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

        //Shake Timer
        if(shake_timer > 0)
        {
            shake_timer -= Time.deltaTime;

            if (shake_timer <= 0)
            {
                CinemachineBasicMultiChannelPerlin cam_perlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cam_perlin.m_AmplitudeGain = 0f;
            }
        }

        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            //Shoot bullet
            if (ScoreManager.instance.is_ingame)
            {
                if (gun_cooldown_timer <= 0)
                {
                    StartCoroutine(Shoot());
                    gun_cooldown_timer = gun_cooldown;
                    CatMovement.instance.is_looked = false;
                }
            }
        }
    }

    public IEnumerator Shoot()
    {
        cat_anim.SetTrigger("Shoot");

        gun_cooldown_timer = 2.5f;

        yield return new WaitForSeconds(0.2f);

        GameObject fired_bullet = Instantiate(bullet, bullet_start_pos.position, Quaternion.Euler(0, 0, 0));
        Rigidbody rb = fired_bullet.GetComponent<Rigidbody>();
        rb.AddForce(bullet_start_pos.forward * bullet_speed);
        Destroy(fired_bullet, bullet_destroy_time);

        CatMovement.instance.Apply_Knockback();
        CatMovement.instance.is_looked = true;

        ShakeCamera(2f, .1f);
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cam_perlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cam_perlin.m_AmplitudeGain = intensity;
        shake_timer = time;
    }
}
