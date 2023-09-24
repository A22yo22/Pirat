using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using System.Text.RegularExpressions;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;

    string leaderboard_key = "globalHighscore";

    public TextMeshProUGUI player_names_t;
    public TextMeshProUGUI player_scores_t;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public IEnumerator Submit_Score_Routine(int score_to_upload)
    {
        bool done = false;
        string player_id = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(player_id, score_to_upload, leaderboard_key, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully uploaded score: " + score_to_upload);
                done = true;
            }
            else
            {
                Debug.Log("Failed " + response.errorData.message);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator Fetch_Highscores_Rotine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboard_key, 10, 0, (response) =>
        {
            if (response.success)
            {
                string temp_player_names = "Names\n";
                string temp_player_scores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for(int i=0; i<members.Length; i++)
                {
                    temp_player_names += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        temp_player_names += members[i].player.name;
                    }
                    else
                    {
                        temp_player_names += members[i].player.id;
                    }

                    temp_player_scores += members[i].score + "\n";
                    temp_player_names += "\n";
                }
                done = true;
                player_names_t.text = temp_player_names;
                player_scores_t.text = temp_player_scores;
            }
            else
            {
                Debug.Log("Failed" + response.errorData.message);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
