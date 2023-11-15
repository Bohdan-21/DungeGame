using Scripts.Infrastructure.Factory;
using Scripts.Services.PlayerProgressService;
using System;

namespace Scripts.Infrastructure.StateMachine
{
    public class WinState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPlayerProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public WinState(GameStateMachine gameStateMachine, IPlayerProgressService progressService, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            //записать прогресс(обновить)
            //перезагрузить сценку

            UpdateProgress();

            _gameStateMachine.Enter<ReloadLevelState>();
        }

        private void UpdateProgress()
        {
            _progressService.PlayerProgress.ClearAllData();

            foreach (IPlayerProgressUpdater progressUpdater in _progressService.ProgressUpdaters)
                progressUpdater.UpdateProgress(_progressService.PlayerProgress);
        }

        public void Exit()
        {
            
        }
    }
}