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
                time_left_t.text = Mathf.RoundToInt(time_left).ToString();
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
        SceneManager.LoadScene("Main Menu");
    }
}
