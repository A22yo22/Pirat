using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerLBManager : MonoBehaviour
{
    public bool is_menu_scene = true;

    public TMP_InputField player_name_inp;

    void Start()
    {
        StartCoroutine(Setup_Routine());


        if (is_menu_scene)
        {
            player_name_inp.characterLimit = 15;
        }
    }

    public void Set_Player_Name()
    {
        LootLockerSDKManager.SetPlayerName(player_name_inp.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Succesflully set player name");
            }
            else
            {
                Debug.Log("Could not set player name" + response.errorData.message);
            }
        });
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

                Debug.Log("RANK: _________________-----: " + LeaderboardManager.instance.Get_rank());

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
