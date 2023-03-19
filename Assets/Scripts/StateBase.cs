using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("Estado atual: STARTGAME");

        // recebe o objeto (no caso a bola)
        base.OnStateEnter(obj);

        // transforma na bola
        BallBase ball = (BallBase)obj;

    }
}

public class StateMenu : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        Debug.Log("Estado atual: MENU");
        base.OnStateEnter();
        GameManager.Instance.ShowMainMenu();
    }
}

public class StatePlaying: StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        Debug.Log("Estado atual: PLAYING");
        base.OnStateEnter();
        GameManager.Instance.StartGame();
    }
}

public class StatePause : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        Debug.Log("Estado atual: PAUSE");
        base.OnStateEnter();
        GameManager.Instance.ShowPauseMenu();
    }
}

public class StateResume : StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        Debug.Log("Estado atual: RESUME");
        base.OnStateEnter();
        GameManager.Instance.ResumeGame();
        StateMachine.Instance.SwitchState(StateMachine.States.PLAYING);
    }
}

public class StateEndGame: StateBase
{
    public override void OnStateEnter(object obj = null)
    {
        Debug.Log("Estado atual: END GAME");
        base.OnStateEnter();
    }
}
