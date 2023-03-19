using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    // Torna um singleton para acesar de todo lugar
    public static GameManager Instance;
    //public StateMachine stateMachine;

    public BallBase ballBase;

    [Header("Menu Settings")]
    public GameObject uiMainMenu;
    public GameObject uiPauseMenu;

    // Start is called before the first frame update
    private void Awake()
    {
        // Cria a instancia do GameManager (Singleton)
        Instance = this;
    }

    public void StartGame()
    {
        ballBase.ballCanMove(true);
    }

    public void ShowMainMenu()
    {
        Debug.Log("ShowMainMenu: Ativo");
        ballBase.ballCanMove(false);
        uiMainMenu.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        Debug.Log("ShowMainMenu: Ativo");
        ballBase.ballCanMove(false);
        uiPauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Debug.Log("ResumeGame: Ativo");
        uiPauseMenu.SetActive(false);
        uiMainMenu.SetActive(false);
        // ballBase.ballCanMove(true);
    }

    public void ResetBallPosition(string currentWay)
    {
        ballBase.ResetBall(currentWay);
    }

}
