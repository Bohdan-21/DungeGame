using Scripts.GameSystem.QuestSystem.Factory;
using Scripts.Infrastructure.Factory;
using Scripts.Services.PlayerProgressService;

namespace Scripts.Infrastructure.StateMachine
{
    public class InitializeLevelState : IState
    {
        private GameStateMachine _levelStateMachine;
        private IGameFactory _gameFactory;
        private readonly IPlayerProgressService _playerProgressService;
        private readonly QuestFactory _questFactory;

        public InitializeLevelState(GameStateMachine levelStateMachine, IGameFactory gameFactory, 
            IPlayerProgressService playerProgressService, QuestFactory questFactory)
        {
            _levelStateMachine = levelStateMachine;
            _gameFactory = gameFactory;
            _playerProgressService = playerProgressService;
            _questFactory = questFactory;
        }

        public void Enter()
        {
            _playerProgressService.Cleanup();

            _gameFactory.CreateLevel();

            LoadDataFromPlayerProgress();

            _levelStateMachine.Enter<GameLoopState>();
        }

        private void LoadDataFromPlayerProgress()
        {
            _playerProgressService.AlertAllLoadData();

            //---------------------------
            _questFactory.RespawnSavedQuest();
            //---------------------------
        }

        public void Exit()
        {
            
        }
    }
}
