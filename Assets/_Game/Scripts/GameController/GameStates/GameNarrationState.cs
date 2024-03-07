using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameNarrationState : State
{

    private GameFSM _stateMachine;
    private GameController _controller;
    private int _narScene = 0;

    // this is our 'cunstructor', called when this state is created
    public GameNarrationState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        _controller.NarrationUI.SetActive(true);


        _controller.NarrationAudio.Play();

        Debug.Log("STATE: game narration");
        Debug.Log("talk talk talk ");
        Debug.Log("blah blah blah");
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
        if (_controller.Input.IsTapPressed == true)
        {
            _controller.NarrationUI.SetActive(false);
            _controller.NarrationAudio.Stop();

            Debug.Log("ExitingState");
            _stateMachine.ChangeState(_stateMachine.PlayState);
        }

    }
}
