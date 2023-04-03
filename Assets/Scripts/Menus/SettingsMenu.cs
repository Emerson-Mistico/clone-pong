using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [Header("References")]
    public GameObject uiNoWinnerMessage;
    public GameObject uiLastWinnerMessage;

    // Update is called once per frame
    void Update()
    {
        string _Winner = PlayerPrefs.GetString("lastWinner");

        if (_Winner != "")
        {
            uiNoWinnerMessage.SetActive(false);
            uiLastWinnerMessage.SetActive(true);
        }
        else {
            uiNoWinnerMessage.SetActive(true);
            uiLastWinnerMessage.SetActive(false);
        }
    }
}
