using Scripts.Infrastructure.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InitBootstrapper : MonoBehaviour
{
    private MainStateMachine _mainStateMachine;

    [Inject]
    private void Construct(MainStateMachine mainStateMachine, LoadSettingsState loadSettingsState, MainMenuState mainMenuState, 
                           GameState gameState, ExitApplicationState exitApplicationState)
    {
        _mainStateMachine = mainStateMachine;

        _mainStateMachine.AddState(loadSettingsState);
        _mainStateMachine.AddState(mainMenuState);
        _mainStateMachine.AddState(gameState);
        _mainStateMachine.AddState(exitApplicationState);
    }

    private void Start()
    {
        _mainStateMachine.Enter<LoadSettingsState>();
    }
}
