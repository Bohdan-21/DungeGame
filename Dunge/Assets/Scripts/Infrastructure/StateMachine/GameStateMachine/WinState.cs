using Scripts.Infrastructure.Factory;
using Scripts.Services.PlayerProgressService;
using Scripts.UI.TeleportingUI;
using System;

namespace Scripts.Infrastructure.StateMachine
{
    public class WinState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPlayerProgressService _progressService;
        private readonly IGameFactory _gameFactory;
        private ITeleportingMenu _teleportingMenu;

        public WinState(GameStateMachine gameStateMachine, IPlayerProgressService progressService, IGameFactory gameFactory,
                        ITeleportingMenu teleportingMenu)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _gameFactory = gameFactory;

            _teleportingMenu = teleportingMenu;
        }

        public void Enter()
        {
            //записать прогресс(обновить)
            //перезагрузить сценку
            bool isMenuShowing = false;

            if (_progressService.PlayerProgress.LevelData.NextLoadRoom == "")
            {
                _teleportingMenu.ShowMenu();
                isMenuShowing = true;
            }

            UpdateProgress();

            if(!isMenuShowing)
                _gameStateMachine.Enter<ReloadLevelState>();
        }

        private void UpdateProgress()
        {
            _progressService.PlayerProgress.ClearAllData();

            _progressService.AlertAllToUpdateData();
        }

        public void Exit()
        {
            
        }
    }
}