using Scripts.Infrastructure.Factory;
using Scripts.Services.PlayerProgressService;

namespace Scripts.Infrastructure.StateMachine
{
    public class InitializeLevelState : IState
    {
        private GameStateMachine _levelStateMachine;
        private IGameFactory _gameFactory;
        private readonly IPlayerProgressService _playerProgressService;

        public InitializeLevelState(GameStateMachine levelStateMachine, IGameFactory gameFactory, 
            IPlayerProgressService playerProgressService)
        {
            _levelStateMachine = levelStateMachine;
            _gameFactory = gameFactory;
            _playerProgressService = playerProgressService;
        }

        public void Enter()
        {
            _playerProgressService.Cleanup();

            _gameFactory.CreateLevel();

            InformProgressReader();

            _levelStateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReader()
        {
            foreach (IPlayerProgressUpdater progressUpdater in _playerProgressService.ProgressUpdaters)
                progressUpdater.LoadProgress(_playerProgressService.PlayerProgress);
        }

        public void Exit()
        {
            
        }
    }
}
