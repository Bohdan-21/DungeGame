using Scripts.GameSystem.LevelGeneration.ConnectionStrategies;
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
            QuitState quitState, WinState winState, IBackgroundAudioPlayer audioPlayer, GenerateLevelState generateLevelState,
            ConnectionStrategyFactory strategyFactory, ForwardConnectionStrategy forwardConnection, 
            TurnableConnectionStrategy turnableConnection, ForkThreePointConnectionStrategy forkThreePointConnection, 
            ForkFourPointConnectionStrategy forkFourPointConnection, DeadEndConnectionStrategy deadEndConnection)
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

            strategyFactory.AddConnectionStrategy(forwardConnection);
            strategyFactory.AddConnectionStrategy(turnableConnection);
            strategyFactory.AddConnectionStrategy(forkThreePointConnection);
            strategyFactory.AddConnectionStrategy(forkFourPointConnection);
            strategyFactory.AddConnectionStrategy(deadEndConnection);
        }

        private void Awake()
        {
            _audioPlayer.PlayBackgroundMusic();

            _gameStateMachine.Enter<GenerateLevelState>();
        }
    }
}