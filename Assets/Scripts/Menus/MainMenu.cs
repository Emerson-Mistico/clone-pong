using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("References")]
    public GameObject uiButtonPlay;
    public GameObject uiButtonPlayAgain;

    private void Update()
    {
        if (StateMachine.Instance.currentStateToShow == "StateEndGame")
        {
            uiButtonPlay.SetActive(false);
            uiButtonPlayAgain.SetActive(true);
        }
    }
}
