using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateBase
{
   public virtual void OnStateEnter(object obj = null)
    {
        // Debug.Log("OnStateEnter");
    }
    
    public virtual void OnStateStay()
    {
        // Debug.Log("OnStateStay");
    }

    public virtual void OnStateExit()
    {
        // Debug.Log("OnStateExit");
    }
           
}

public class StateStartGame: StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        // receives the object (in this case the ball)
        base.OnStateEnter(obj);
        BallBase ball = (BallBase)obj;        
        //Debug.Log("State : StartGame");
    }
}

public class StateWelcomeScreen : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        base.OnStateEnter();
        GameManager.Instance.ShowWelcomeScreen();
        //Debug.Log("State : WelcomeScreen");
    }
}

public class StateMenu : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        base.OnStateEnter();
        GameManager.Instance.ShowMainMenu();
        //Debug.Log("State : Menu");
    }
}

public class StatePlaying: StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        base.OnStateEnter();
        //Debug.Log("State : Playing");
    }
}

public class StatePause : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        base.OnStateEnter();
        GameManager.Instance.ShowPauseMenu();
        //Debug.Log("State : Pause");
    }
}

public class StateResume : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        base.OnStateEnter();
        GameManager.Instance.ResumeGame();
        //Debug.Log("State : Resume");
    }
}

public class StateEndGame: StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        GameManager.Instance.ShowEndGameMenu();
        //Debug.Log("State : EndGame");
    }
}

public class StateQuitGame : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        Application.Quit();
        //Debug.Log("State : QuitGame");
    }
}
