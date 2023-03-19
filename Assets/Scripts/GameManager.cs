using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    // GameManager to singleton
    public static GameManager Instance;    

    public BallBase ballBase;

    [Header("Menu Settings")]
    public GameObject uiMainMenu;
    public GameObject uiPauseMenu;

    // Start is called before the first frame update
    private void Awake()
    {
        // Instanciate GameManager (Singleton)
        Instance = this;
    }

    public void StartGame()
    {
        ballBase.ballCanMove(true);
    }

    public void ShowMainMenu()
    {
        ballBase.ballCanMove(false);
        uiMainMenu.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        ballBase.ballCanMove(false);
        uiPauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        uiPauseMenu.SetActive(false);
        uiMainMenu.SetActive(false);
        ballBase.ballCanMove(true);
        StateMachine.Instance.SwitchState(StateMachine.States.PLAYING);
    }

    public void ResetBallPosition(string currentWay)
    {
        ballBase.ResetBall(currentWay);
    }

}
