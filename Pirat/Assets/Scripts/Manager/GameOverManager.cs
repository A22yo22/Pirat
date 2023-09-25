using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Play_Again()
    {
        SceneManager.LoadScene("Main World");
    }

    public void Back_To_Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
