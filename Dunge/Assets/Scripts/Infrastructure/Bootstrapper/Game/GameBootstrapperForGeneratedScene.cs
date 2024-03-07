using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure
{
    public class GameBootstrapperForGeneratedScene : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private IBackgroundAudioPlayer _audioPlayer;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, ReloadLevelState enterLevelState,
            InitializeLevelState initializeLevelState, GameLoopState gameLoopState, DeathState deathState,
            QuitState quitState, WinState winState, IBackgroundAudioPlayer audioPlayer, GenerateLevelState generateLevelState)
        {
            _gameStateMachine = gameStateMachine;

            _gameStateMachine.AddState(enterLevelState);
            _gameStateMachine.AddState(initializeLevelState);
            _gameStateMachine.AddState(gameLoopState);
            _gameStateMachine.AddState(deathState);
            _gameStateMachine.AddState(quitState);
            _gameStateMachine.AddState(winState);

            _gameStateMachine.AddState(generateLevelState);

            _audioPlayer = audioPlayer;
        }

        private void Awake()
        {
            _gameStateMachine.Enter<GenerateLevelState>();

            _audioPlayer.PlayBackgroundMusic();
        }
    }
}