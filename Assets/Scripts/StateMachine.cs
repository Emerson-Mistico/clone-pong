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
    public string currentStateToShow;
    
    private void Awake()
    {
        #region Singleton StateMachine
        Instance = this;
        #endregion

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

    private void Start()
    {

        if (_currentState.ToString() == "StateStartGame")
        {
            SwitchState(States.MENU);
        }
    }

    private void Update()
    {

        if (_currentState.ToString() == "StatePlaying")
        {
            GameManager.Instance.ballBase.ballCanMove(true);
        } else
        {
            GameManager.Instance.ballBase.ballCanMove(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            switch (_currentState.ToString())
            {
                case 
                    "StatePlaying":
                        SwitchState(States.PAUSE);
                    break;
                case
                    "StatePause":
                        SwitchState(States.RESUME_GAME);
                    break;
            }

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

        // To check the state in other places
        currentStateToShow = _currentState.ToString();

        // Debug.Log ("State: " + currentStateToShow);

    }
  
}
