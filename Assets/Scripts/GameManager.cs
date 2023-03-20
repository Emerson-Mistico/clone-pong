using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    // GameManager to singleton
    public static GameManager Instance;

    [Header ("Game Settings")]
    public BallBase ballBase;
    public int pointsToWin = 3;

    [Header("Menu Settings")]
    public GameObject uiMainMenu;
    public GameObject uiPauseMenu;
    public GameObject uiSettingsMenu;

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

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        StateMachine.Instance.SwitchState(StateMachine.States.END_GAME);
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

    public void ShowSettingsMenu()
    {
        uiSettingsMenu.SetActive(true);
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
