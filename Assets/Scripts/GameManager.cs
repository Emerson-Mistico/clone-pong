using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class GameManager : MonoBehaviour
{
    
    // GameManager to singleton
    public static GameManager Instance;

    [Header ("Game Settings")]
    public BallBase ballBase;
    public TMP_InputField inputFieldPointsToWin;
    public IntVariable instructiuonsPointsToWin;

    public int defaultPointsToWin = 3;

    public TextMeshProUGUI hudPointsPlayer1;
    public TextMeshProUGUI hudPointsPlayer2;
    public TextMeshProUGUI scorePointsPlayer1;
    public TextMeshProUGUI scorePointsPlayer2;

    [Header("Menu Settings References")]
    public GameObject uiMainMenu;
    public GameObject uiPauseMenu;
    public GameObject uiSettingsMenu;
    public GameObject uiEndGameMenu;
    public GameObject uiInstructionsScreen;
    public TextMeshProUGUI uiLastWinner;
    public TextMeshProUGUI uiLastWinnerEndGame;


    [Header("Players references")]
    public Player refPlayer1;
    public Player refPlayer2;

    private string _currentPointsToWin;

    // Start is called before the first frame update
    private void Awake()
    {
        #region Singleton Gamemanager
        Instance = this;
        #endregion

        // set as default values to play
        inputFieldPointsToWin.text = defaultPointsToWin.ToString();
        PlayerPrefs.SetInt("pointsToWin", defaultPointsToWin);
        PlayerPrefs.SetString("lastWinner", "");
        PlayerPrefs.SetString("namePlayer1", "");
        PlayerPrefs.SetString("namePlayer2", "");

        GlobalPointsUpdate(PlayerPrefs.GetInt("pointsToWin"));

        #region Global Player Keys Update
        // update global variables to localization
        var source = LocalizationSettings.StringDatabase.SmartFormatter.GetSourceExtension<PersistentVariablesSource>();
        StringVariable _instructionsP1keyUP = source["global"]["player1KeyUP"] as StringVariable;
        StringVariable _instructionsP1keyDOWN = source["global"]["player1KeyDOWN"] as StringVariable;
        StringVariable _instructionsP2keyUP = source["global"]["player2KeyUP"] as StringVariable;
        StringVariable _instructionsP2keyDOWN = source["global"]["player2KeyDOWN"] as StringVariable;
        _instructionsP1keyUP.Value = refPlayer1.keyCodeMoveUp.ToString();
        _instructionsP1keyDOWN.Value = refPlayer1.keycodeMoveDown.ToString();
        _instructionsP2keyUP.Value = refPlayer2.keyCodeMoveUp.ToString();
        _instructionsP2keyDOWN.Value = refPlayer2.keycodeMoveDown.ToString();
        #endregion
    }

    #region General Manipulation
    public void DoChangePointsToWin()
    {
        _currentPointsToWin = inputFieldPointsToWin.text;
        PlayerPrefs.SetInt("pointsToWin", int.Parse(_currentPointsToWin));

        GlobalPointsUpdate(PlayerPrefs.GetInt("pointsToWin"));

        ResetBallPosition(PlayerPrefs.GetString("lastWinner"), false);
        refPlayer1.currentPoints = 0;
        refPlayer2.currentPoints = 0;
        hudPointsPlayer1.text = "0";
        hudPointsPlayer2.text = "0";
        scorePointsPlayer1.text = "0";
        scorePointsPlayer2.text = "0";

    }
    public void GlobalPointsUpdate(int points)
    {
        // update global variables to localization
        var source = LocalizationSettings.StringDatabase.SmartFormatter.GetSourceExtension<PersistentVariablesSource>();
        instructiuonsPointsToWin = source["global"]["pointsToWin"] as IntVariable;
        instructiuonsPointsToWin.Value = points;
    }

    public void ResetBallPosition(string currentWay, bool moveBall)
    {
        ballBase.ResetBall(currentWay, moveBall);
    }

    public void DisableAllScreens()
    {
        uiPauseMenu.SetActive(false);
        uiMainMenu.SetActive(false);
        uiEndGameMenu.SetActive(false);
        uiSettingsMenu.SetActive(false);
        uiInstructionsScreen.SetActive(false);
    }


    #endregion

    #region Game Manipulation
    public void StartGame()
    {
        ballBase.ballCanMove(true);
    }

    public void EndGame(string winnerPlayer)
    {
        PlayerPrefs.SetString("lastWinner", winnerPlayer);
        uiLastWinner.text = winnerPlayer;
        uiLastWinnerEndGame.text = winnerPlayer;
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
        scorePointsPlayer1.text = "0";
        scorePointsPlayer2.text = "0";
        StateMachine.Instance.SwitchState(StateMachine.States.PLAYING);
    }
    public void ResumeGame()
    {
        DisableAllScreens();
        StateMachine.Instance.SwitchState(StateMachine.States.PLAYING);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SCN_Pong");
    }

    public void ShowCreditsScene()
    {
        SceneManager.LoadScene("SCN_Credits");
    }

    public void QuitGame()
    {
        StateMachine.Instance.SwitchState(StateMachine.States.QUIT_GAME);
    }
    #endregion

    #region Menu manipulations
    public void ShowMainMenu()
    {

        // ballBase.ballCanMove(false);
        uiMainMenu.SetActive(true);
        
    }

    public void ShowInstructionsScreen()
    {

        // ballBase.ballCanMove(false);
        uiInstructionsScreen.SetActive(true);

    }

    public void ShowPauseMenu()
    {
        // ballBase.ballCanMove(false);
        uiPauseMenu.SetActive(true);
    }

    public void ShowSettingsMenu()
    {
        // ballBase.ballCanMove(false);
        uiSettingsMenu.SetActive(true);
    }
    public void ShowEndGameMenu()
    {
        // ballBase.ballCanMove(false);
        uiEndGameMenu.SetActive(true);
    }
    #endregion

}
