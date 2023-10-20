using Scripts.Data.SaveData;
using Scripts.Services.PlayerProgressService;
using Scripts.Services.SaveLoad;
using Scripts.StaticData.PlayerStaticData;
using System;

namespace Scripts.Infrastructure.StateMachine.MenuStateMachine
{
    public class LoadPlayerProgressState : IState
    {
        MainStateMachine _mainStateMachine;
        private readonly IPlayerProgressService _playerProgressService;
        private readonly ISaveLoadService _saveLoadService;
        PlayerCharacterDeffaultSettings _playerCharacterDeffaultSettings;

        public LoadPlayerProgressState(MainStateMachine mainStateMachine, ISaveLoadService saveLoadService,
            IPlayerProgressService playerProgressService, PlayerCharacterDeffaultSettings playerCharacterDeffaultSettings)
        {
            _mainStateMachine = mainStateMachine;
            _saveLoadService = saveLoadService;
            _playerProgressService = playerProgressService;
            _playerCharacterDeffaultSettings = playerCharacterDeffaultSettings;
        }

        public void Enter()
        {
            _playerProgressService.PlayerProgress = _saveLoadService.LoadProgress() ?? CreateNewPlayerProgress();

            _mainStateMachine.Enter<GameState>();
        }

        private PlayerProgress CreateNewPlayerProgress()
        {
            return new PlayerProgress(_playerCharacterDeffaultSettings.LevelData,
                                      _playerCharacterDeffaultSettings.State,
                                      _playerCharacterDeffaultSettings.Inventory);
        }

        public void Exit()
        {
            
        }
    }
}
