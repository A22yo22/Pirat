using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public bool is_ingame = true;

    public int score;
    public float time_left = 300;

    public TMP_Text score_t;
    public TMP_Text time_left_t;

    public GameObject game_ui_screen;
    public GameObject game_finished_screen;
    public TMP_Text score_t_over;

    [Header("Timer Sounds")]
    public AudioClip ten_sec_sounds;
    public AudioClip thrity_sec_sounds;
    public AudioSource audio_controller;
    bool thirty_played;
    bool ten_played;

    private void Awake()
    {
        if(instance == null) { instance = this; }
    }

    private void Update()
    {
        if (is_ingame)
        {
            if (time_left > 0)
            {
                time_left -= Time.deltaTime;
                time_left_t.text = "Time Left: " + Mathf.RoundToInt(time_left).ToString();

                if (time_left >= 29f && time_left <= 30f && !thirty_played)
                {
                    audio_controller.clip = thrity_sec_sounds;
                    audio_controller.Play();
                }
                else if(time_left >= 9f && time_left <= 10f && !thirty_played)
                {
                    audio_controller.clip = ten_sec_sounds;
                    audio_controller.Play();
                }
            }
            else
            {
                Game_Finished();
                is_ingame = false;
            }
        }
    }

    public void Add_Score(int amount)
    {
        score += amount;
        score_t.text = "Score: " + score;
    }

    public void Game_Over()
    {
        //No score to save
    }

    public void Game_Finished()
    {
        StartCoroutine(LeaderboardManager.instance.Submit_Score_Routine(score));
        //SceneManager.LoadScene("Main Menu");

        //Open Game Finished Screen
        game_ui_screen.SetActive(false);

        game_finished_screen.SetActive(true);

        score_t_over.text = "Score: " + score;

        LeaderboardManager.instance.Fetch_Highscores_Rotine();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
