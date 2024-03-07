using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private float _timer;
    private float _timeLimit = 4;

    // this is our 'cunstructor', called when this state is created
    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.SetupUI.SetActive(true);
        _controller.SetupAduio.Play();
        Debug.Log("STATE: Game Setup");
        Debug.Log("Load Save Data");
        Debug.Log("Spawn Units");

        _controller.UnitSpawner.Spawn(_controller.PlayerUnitPrefab,
            _controller.PlayerUnitSpawnLocation);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
        _timer += Time.deltaTime;

    }

    public override void Tick()
    {
        base.Tick();
        if (_timer >= _timeLimit)
        {
            _controller.SetupUI.SetActive(false);
            _controller.SetupAduio.Stop();

            Debug.Log("ExitingState");
            _stateMachine.ChangeState(_stateMachine.NarrationState);
        }
    }
}
