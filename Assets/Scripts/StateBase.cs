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
    }
}

public class StateMenu : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        base.OnStateEnter();
        GameManager.Instance.ShowMainMenu();
    }
}

public class StatePlaying: StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        base.OnStateEnter();
    }
}

public class StatePause : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        base.OnStateEnter();
        GameManager.Instance.ShowPauseMenu();
    }
}

public class StateResume : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        base.OnStateEnter();
        GameManager.Instance.ResumeGame();
    }
}

public class StateEndGame: StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        GameManager.Instance.ShowEndGameMenu();
    }
}

public class StateQuitGame : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        Application.Quit();
        // Debug.Log("Jogo finalizado");
    }
}
