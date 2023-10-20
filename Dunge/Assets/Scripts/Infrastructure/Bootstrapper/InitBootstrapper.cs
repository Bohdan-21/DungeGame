using Scripts.Infrastructure.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InitBootstrapper : MonoBehaviour
{
    private MainStateMachine _mainStateMachine;
    private GameStateMachine _levelStateMachine;

    [Inject]
    private void Construct(MainStateMachine mainStateMachine, MainMenuState mainMenuState, GameState gameState)
    {
        _mainStateMachine = mainStateMachine;

        _mainStateMachine.AddState(mainMenuState);
        _mainStateMachine.AddState(gameState);
    }

    private void Awake()
    {
        _mainStateMachine.Enter<MainMenuState>();
    }
}
