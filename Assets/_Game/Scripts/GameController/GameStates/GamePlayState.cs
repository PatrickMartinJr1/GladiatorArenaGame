using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private GameObject _playerRef;
    static public int _killCount = 0;
    private int _killsNeeded = 15;

    // this is our 'cunstructor', called when this state is created
    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {



        base.Enter();
        _killCount = 0;
        _playerRef = GameObject.FindGameObjectWithTag("Player");
        _controller._enemySpawner1.SetActive(true);
        _controller._enemySpawner2.SetActive(true);
        // _controller.PlayUI.SetActive(true);
        _controller.PlayAudio.Play();

        Debug.Log("STATE: Game Play");
        Debug.Log("Listen for player inputs");
        Debug.Log("Display player HUD");
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

        //check for win condition
        if (_killCount >= _killsNeeded)
        {
            _controller.PlayUI.SetActive(false);
            _controller.PlayAudio.Stop();
            Time.timeScale = 0;
            _stateMachine.ChangeState(_stateMachine.WinState);
            //reload level, change back to SetupState, etc.
        }

        // check for lose condition
        else if (_playerRef.activeInHierarchy == false)
        {
            _controller.PlayUI.SetActive(false);
            _controller.PlayAudio.Stop();
            Time.timeScale = 0;
            _stateMachine.ChangeState(_stateMachine.LoseState);

        }
    }

}
