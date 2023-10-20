using Scripts.Infrastructure.Factory;
using Scripts.Services.PlayerProgressService;
using Scripts.Services.SaveLoad;
using UnityEngine;

namespace Scripts.Infrastructure.StateMachine
{
    public class QuitState : IState
    {
        private MainStateMachine _mainStateMachine;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPlayerProgressService _playerProgressService;

        public QuitState(MainStateMachine mainStateMachine, ISaveLoadService saveLoadService, 
            IPlayerProgressService playerProgressService)
        {
            _mainStateMachine = mainStateMachine;
            _saveLoadService = saveLoadService;
            _playerProgressService = playerProgressService;
        }

        public void Enter()
        {
            //записали прогресс(обновили)
            //сохранили прогресс 
            //вышли из состояния

            _saveLoadService.SaveProgress();

            _mainStateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {

        }
    }
}