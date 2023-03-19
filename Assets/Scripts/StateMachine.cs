using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // Tornar a StateMachine um singleton (precisei ;-))
    public static StateMachine Instance;

    public enum States
    {
        START_GAME,
        MENU,
        PLAYING,
        PAUSE,
        RESUME_GAME,
        END_GAME
    }

    //Chave
    public Dictionary<States, StateBase> dictionaryState;
        
    private StateBase _currentState;
    // public Player player;
    // public float timeToStartGame = 2f;

    private void Awake()
    {
        // Cria a instancia do StateMachine (Singleton)
        Instance = this;

        // Debug.Log("State Machine em Awake");
        dictionaryState = new Dictionary<States, StateBase>();

        dictionaryState.Clear();
        dictionaryState.Add(States.START_GAME, new StateStartGame());
        dictionaryState.Add(States.MENU, new StateMenu());
        dictionaryState.Add(States.PLAYING, new StatePlaying());
        dictionaryState.Add(States.PAUSE, new StatePause());
        dictionaryState.Add(States.RESUME_GAME, new StateResume());
        dictionaryState.Add(States.END_GAME, new StateEndGame());

        SwitchState(States.START_GAME);

    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) 
            && (_currentState.ToString() != "StatePause") 
            && (_currentState.ToString() != "StateMenu"))
        {
            Debug.Log("Apertou Scape: Entrar na PAUSA");
            SwitchState(States.PAUSE);
        } 
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Apertou Scape: Sair da PAUSA");
            SwitchState(States.RESUME_GAME);
        } 
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Apertou Scape: Entrar no MENU");
            SwitchState(States.MENU);
        }        
        else if (Input.GetKeyDown(KeyCode.Q)) 
        {
            Debug.Log("Apertou Q: Tela final/sair");
            SwitchState(States.END_GAME);
        }
    }

    public void SwitchState(States state)
    {
        if (_currentState != null)
        {
            _currentState.OnStateExit();
        }

        _currentState = dictionaryState[state];            

        if (_currentState != null ) 
        { 
            _currentState.OnStateEnter(); 
        }
    }
  
}
