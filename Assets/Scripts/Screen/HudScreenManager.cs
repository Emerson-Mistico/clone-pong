using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScreenManager : MonoBehaviour
{
    
    [Header("References")]
    public GameObject uiNoNamePlayer1;
    public GameObject uiNoNamePlayer2;
    public GameObject uiPlayerNamePlayer1;
    public GameObject uiPlayerNamePlayer2;

    // Update is called once per frame
    void Update()
    {
        string _player1Name = PlayerPrefs.GetString("namePlayer1");
        string _player2Name = PlayerPrefs.GetString("namePlayer2");

        if (_player1Name != "")
        {
            uiNoNamePlayer1.SetActive(false);
            uiPlayerNamePlayer1.SetActive(true);

        }

        if (_player2Name != "")
        {
            uiNoNamePlayer2.SetActive(false);
            uiPlayerNamePlayer2.SetActive(true);

        }

    }
}
