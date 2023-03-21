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
    public int defaultPointsToWin = 3;
    public TMP_InputField inputFieldPointsToWin;

    public string defaultPlayerName1 = "Jogador 1";
    public string defaultPlayerName2 = "Jogador 2";

    [Header ("HUD References")]
    public TextMeshProUGUI hudPlayerName1;
    public TextMeshProUGUI hudPlayerName2;

    [Header("Menu Settings References")]
    public GameObject uiMainMenu;
    public GameObject uiPauseMenu;
    public GameObject uiSettingsMenu;
    public GameObject uiEndGameMenu;

    private string _currentPointsToWin;
    private string _lastWinner = "Sem vencedor";

    // Start is called before the first frame update
    private void Awake()
    {
        // Instanciate GameManager (Singleton)
        Instance = this;

        inputFieldPointsToWin.text = defaultPointsToWin.ToString();
        PlayerPrefs.SetInt("pointsToWin", defaultPointsToWin);
        PlayerPrefs.SetString("lastWinner", _lastWinner);

        hudPlayerName1.text = defaultPlayerName1.ToString();
        hudPlayerName2.text = defaultPlayerName2.ToString();

    }

    public void DoChangePointsToWin()
    {
        _currentPointsToWin = inputFieldPointsToWin.text;
    }

    public void StartGame()
    {
        ballBase.ballCanMove(true);
    }

    public void EndGame(string winnerPlayer)
    {
        PlayerPrefs.SetString("lastWinner", winnerPlayer);
        ballBase.ballCanMove(false);
        StateMachine.Instance.SwitchState(StateMachine.States.END_GAME);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
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
        uiEndGameMenu.SetActive(true);
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
