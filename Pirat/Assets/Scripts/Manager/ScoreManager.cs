using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text score_t;

    public int score;

    private void Awake()
    {
        if(instance == null) { instance = this; }
    }

    public void Add_Score(int amount)
    {
        score += amount;
        score_t.text = "Score: " + score;
        if (score >= 500)
        {
            Game_Finished();
        }
    }

    public void Game_Over()
    {
        //No score to save
    }

    public void Game_Finished()
    {
        Debug.Log("Score");
        StartCoroutine(LeaderboardManager.instance.Submit_Score_Routine(score));
    }
}
