using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score;

    private void Awake()
    {
        if(instance == null) { instance = this; }
    }

    public void Add_Score(int amount)
    {
        score += amount;
    }
}
