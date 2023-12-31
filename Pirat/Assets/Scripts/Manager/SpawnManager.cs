using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [Header("Spawn Stuff")]
    public bool spawn_alowance;

    public float spawn_time;
    public GameObject walking_rat_pf;

    public Transform spawn_pos_start;
    public Transform spawn_pos;

    [Header("Rotation")]
    public float ratation_speed = 60f;
    Quaternion start_rotation;
    Quaternion rotation_destination;

    [Header("Sound")]
    public List<AudioClip> bibbub_sounds;
    public AudioSource audio_controller;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Start_Set_Spawn_Pos();
            Spawn_Walking_Rat_Start();
        }

        StartCoroutine(Spawn_Walking_Rat_Timer());
    }


    private void Update()
    {
        if (rotation_destination != transform.rotation)
        {
            transform.rotation = Quaternion.Slerp(start_rotation, rotation_destination, Time.deltaTime);
        }
        else if (spawn_alowance)
        {
            Spawn_Walking_Rat();
            spawn_alowance = false;
        }
    }

    public IEnumerator Spawn_Walking_Rat_Timer()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);

        yield return new WaitForSeconds(spawn_time);

        spawn_alowance = true;

        Set_Spawn_Pos();

        //Play Audio
        audio_controller.pitch = Random.Range(0.8f, 1.2f);
        audio_controller.clip = bibbub_sounds[Random.Range(0, 3)];
        audio_controller.Play();

        StartCoroutine(Spawn_Walking_Rat_Timer());
    }

    //Sounds


    public void Start_Set_Spawn_Pos()
    {
        Quaternion rot = Quaternion.Euler(Random.Range(0, 360),
                                                     Random.Range(0, 360),
                                                     Random.Range(0, 360));

        transform.rotation = rot;
    }

    public void Set_Spawn_Pos()
    {
        rotation_destination = Quaternion.Euler(Random.Range(0, 360),
                                                     Random.Range(0, 360),
                                                     Random.Range(0, 360));
    }

    public void Spawn_Walking_Rat_Start()
    {
        GameObject walking_rat = Instantiate(walking_rat_pf, spawn_pos_start.position, Quaternion.identity);
    }

    public void Spawn_Walking_Rat()
    {
        GameObject walking_rat = Instantiate(walking_rat_pf, spawn_pos.position, Quaternion.identity);
    }
}
