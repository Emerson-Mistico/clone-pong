using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    // GameManager to singleton
    public static GameManager Instance;

    [Header ("Game Settings")]
    public BallBase ballBase;
    public TMP_InputField inputFieldPointsToWin;

    public int defaultPointsToWin = 3;
    public string defaultPlayerName1 = "Jogador 1";
    public string defaultPlayerName2 = "Jogador 2";

    [Header ("HUD References")]
    public TextMeshProUGUI hudPlayerName1;
    public TextMeshProUGUI hudPlayerName2;
    public TextMeshProUGUI hudPointsPlayer1;
    public TextMeshProUGUI hudPointsPlayer2;
    public TextMeshProUGUI hudLastWinner;
    public TextMeshProUGUI hudLastWinnerSettings;

    [Header("Menu Settings References")]
    public GameObject uiMainMenu;
    public GameObject uiPauseMenu;
    public GameObject uiSettingsMenu;
    public GameObject uiEndGameMenu;

    [Header("Players references")]
    public Player refPlayer1;
    public Player refPlayer2;

    private string _currentPointsToWin;
    private string _lastWinner = "Sem vencedor no momento";

    // Start is called before the first frame update
    private void Awake()
    {
        // Instanciate GameManager (Singleton)
        Instance = this;

        // set as default values to play
        inputFieldPointsToWin.text = defaultPointsToWin.ToString();
        PlayerPrefs.SetInt("pointsToWin", defaultPointsToWin);
        PlayerPrefs.SetString("lastWinner", _lastWinner);

        // update HUD and Menu point values
        hudLastWinner.text = _lastWinner;
        hudLastWinnerSettings.text = _lastWinner;
        hudPlayerName1.text = defaultPlayerName1.ToString();
        hudPlayerName2.text = defaultPlayerName2.ToString();   

}

    public void DoChangePointsToWin()
    {
        _currentPointsToWin = inputFieldPointsToWin.text;
        PlayerPrefs.SetInt("pointsToWin", int.Parse(_currentPointsToWin));
        PlayAgain(false);
        StateMachine.Instance.SwitchState(StateMachine.States.PLAYING);
    }
    public void StartGame()
    {
        ballBase.ballCanMove(true);
    }

    public void EndGame(string winnerPlayer)
    {
        PlayerPrefs.SetString("lastWinner", winnerPlayer);
        hudLastWinner.text = winnerPlayer;
        hudLastWinnerSettings.text = winnerPlayer;
        ballBase.ballCanMove(false);
        StateMachine.Instance.SwitchState(StateMachine.States.END_GAME);
    }

    public void PlayAgain(bool moveBall)
    {
        ResetBallPosition(PlayerPrefs.GetString("lastWinner"), moveBall);
        refPlayer1.currentPoints = 0;
        refPlayer2.currentPoints = 0;
        hudPointsPlayer1.text = "0";
        hudPointsPlayer2.text = "0";
        StateMachine.Instance.SwitchState(StateMachine.States.PLAYING);
    }
    public void ResumeGame()
    {
        uiPauseMenu.SetActive(false);
        uiMainMenu.SetActive(false);
        ballBase.ballCanMove(true);
        StateMachine.Instance.SwitchState(StateMachine.States.PLAYING);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        StateMachine.Instance.SwitchState(StateMachine.States.QUIT_GAME);
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
    public void ShowEndGameMenu()
    {
        ballBase.ballCanMove(false);
        uiEndGameMenu.SetActive(true);
    }

    public void ResetBallPosition(string currentWay, bool moveBall)
    {
        ballBase.ResetBall(currentWay, moveBall);
    }

}
