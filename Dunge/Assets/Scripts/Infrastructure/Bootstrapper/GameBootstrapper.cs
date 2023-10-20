using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.StateMachine;
using Scripts.Level;
using Scripts.Player;
using Scripts.StaticData.ProjectGlobalSettings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private IBackgroundAudioPlayer _audioPlayer;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, ReloadLevelState enterLevelState, 
            InitializeLevelState initializeLevelState, GameLoopState gameLoopState, DeathState deathState, 
            QuitState quitState, WinState winState, IBackgroundAudioPlayer audioPlayer)
        {
            _gameStateMachine = gameStateMachine;

            _gameStateMachine.AddState(enterLevelState);
            _gameStateMachine.AddState(initializeLevelState);
            _gameStateMachine.AddState(gameLoopState);
            _gameStateMachine.AddState(deathState);
            _gameStateMachine.AddState(quitState);
            _gameStateMachine.AddState(winState);

            _audioPlayer = audioPlayer;
        }

        private void Awake()
        {
            _gameStateMachine.Enter<InitializeLevelState>();

            _audioPlayer.PlayBackgroundMusic();
        }
    }
}