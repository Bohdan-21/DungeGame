using Scripts.GameSystem.QuestSystem.Factory;
using Scripts.Infrastructure.Factory;
using Scripts.Services.PlayerProgressService;
using Scripts.UI.Curtain;

namespace Scripts.Infrastructure.StateMachine
{
    public class InitializeLevelState : IState
    {
        private GameStateMachine _levelStateMachine;
        private IGameFactory _gameFactory;
        private readonly IPlayerProgressService _playerProgressService;
        private readonly QuestFactory _questFactory;
        private readonly ICurtain _curtain;

        public InitializeLevelState(GameStateMachine levelStateMachine, IGameFactory gameFactory, 
            IPlayerProgressService playerProgressService, QuestFactory questFactory, ICurtain curtain)
        {
            _levelStateMachine = levelStateMachine;
            _gameFactory = gameFactory;
            _playerProgressService = playerProgressService;
            _questFactory = questFactory;
            _curtain = curtain;
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
            _curtain.Hide();
        }
    }
}
