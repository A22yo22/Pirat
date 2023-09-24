using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class PlayerLBManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Setup_Routine());
    }

    IEnumerator Setup_Routine()
    {
        yield return Login_Routine();
        yield return LeaderboardManager.instance.Fetch_Highscores_Rotine();
    }

    IEnumerator Login_Routine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if(response.success)
            {
                Debug.Log("Player was logged in!");

                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
