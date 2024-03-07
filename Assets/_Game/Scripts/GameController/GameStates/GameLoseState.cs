using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoseState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;


    // this is our 'cunstructor', called when this state is created
    public GameLoseState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.LoseUI.SetActive(true);
        _controller.LoseAudio.Play();

        Debug.Log("STATE: Lose State");
        Debug.Log("you lose!");

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

    }
}
