using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    public AudioSource audio_controller;

    public void Click()
    {
        //Play Audio
        audio_controller.pitch = Random.Range(0.8f, 1.2f);
        audio_controller.Play();
    }
}
