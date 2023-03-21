using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // StateMachine to singleton
    public static StateMachine Instance;

    public enum States
    {
        START_GAME,
        MENU,
        PLAYING,
        PAUSE,
        RESUME_GAME,
        END_GAME,
        QUIT_GAME
    }

    // Key
    public Dictionary<States, StateBase> dictionaryState;
        
    private StateBase _currentState;
    // public Player player;
    // public float timeToStartGame = 2f;

    private void Awake()
    {
        // Instanciate StateMachine (Singleton)
        Instance = this;

        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Clear();
        dictionaryState.Add(States.START_GAME, new StateStartGame());
        dictionaryState.Add(States.MENU, new StateMenu());
        dictionaryState.Add(States.PLAYING, new StatePlaying());
        dictionaryState.Add(States.PAUSE, new StatePause());
        dictionaryState.Add(States.RESUME_GAME, new StateResume());
        dictionaryState.Add(States.END_GAME, new StateEndGame());
        dictionaryState.Add(States.QUIT_GAME, new StateQuitGame());

        SwitchState(States.START_GAME);

    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && (_currentState.ToString() != "StatePause") && (_currentState.ToString() != "StateMenu"))
        {
            // Pause game at anytime
            SwitchState(States.PAUSE);
        } 
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit Pause or Menu and resume game
            SwitchState(States.RESUME_GAME);
        } 
        else if (_currentState.ToString() == "StateStartGame")
        {
            SwitchState(States.MENU);
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