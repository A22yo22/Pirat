using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject main_menu_obj;
    public GameObject leaderboard_obj;
    public GameObject options_obj;
    public GameObject credits_obj;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        main_menu_obj.SetActive(true);
        leaderboard_obj.SetActive(true);
    }

    public void Start_Game()
    {
        SceneManager.LoadScene("Main World");
    }

    public void Options()
    {
        //Disable
        main_menu_obj.SetActive(false);
        leaderboard_obj.SetActive(false);

        //Enable
        options_obj.SetActive(true);
    }

    public void Credits()
    {
        //Disable
        main_menu_obj.SetActive(false);
        leaderboard_obj.SetActive(false);

        //Enable
        credits_obj.SetActive(true);
    }

    public void Back()
    {
        //Disable
        options_obj.SetActive(false);
        credits_obj.SetActive(false);

        //Enable
        main_menu_obj.SetActive(true);
        leaderboard_obj.SetActive(true);
    }
}
