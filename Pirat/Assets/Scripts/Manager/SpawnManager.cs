using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public GameObject walking_rat_pf;
    public GameObject flying_rat_pf;

    public Transform spawn_pos;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    private void Start()
    {
        for(int i=0; i < 10; i++)
        {
            Set_Spawn_Pos();
            Spawn_Walking_Rat();
        }
    }

    public void Set_Spawn_Pos()
    {
        Quaternion spawn_rotation = Quaternion.Euler(Random.Range(0, 360),
                                                    Random.Range(0, 360),
                                                    Random.Range(0, 360));
        transform.rotation = spawn_rotation;
    }

    public void Spawn_Walking_Rat()
    {
        GameObject walking_rat = Instantiate(walking_rat_pf, spawn_pos.position, Quaternion.identity);
    }
}
