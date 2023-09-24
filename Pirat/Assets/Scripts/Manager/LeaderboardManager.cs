using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;

    string leaderboard_key = "globalHighscore";

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
                Debug.Log("Successfully uploaded score");
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
}
