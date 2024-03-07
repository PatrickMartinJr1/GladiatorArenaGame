using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;



    // this is our 'cunstructor', called when this state is created
    public GameWinState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.WinUI.SetActive(true);
        _controller.WinAudio.Play();


        //insert audio instantiate here
        Debug.Log("STATE: Win State");
        Debug.Log("you win!");

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
