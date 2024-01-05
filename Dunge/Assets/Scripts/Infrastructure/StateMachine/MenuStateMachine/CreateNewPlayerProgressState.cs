using Scripts.SaveData;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.PlayerStaticData;

namespace Scripts.Infrastructure.StateMachine.MenuStateMachine
{
    public class CreateNewPlayerProgressState : IState
    {
        MainStateMachine _mainStateMachine;
        IPlayerProgressService _playerProgressService;
        PlayerCharacterDeffaultSettings _playerCharacterDeffaultSettings;
        
        public CreateNewPlayerProgressState(MainStateMachine mainStateMachine, IPlayerProgressService playerProgressService, 
            PlayerCharacterDeffaultSettings playerCharacterDeffaultSettings)
        {
            _mainStateMachine = mainStateMachine;
            _playerCharacterDeffaultSettings = playerCharacterDeffaultSettings;
            _playerProgressService = playerProgressService;
        }

        public void Enter()
        {
            CreateNewPlayerProgress();

            _mainStateMachine.Enter<GameState>();
        }

        public void Exit()
        {

        }

        private void CreateNewPlayerProgress()
        {
            _playerProgressService.PlayerProgress = new PlayerProgress(_playerCharacterDeffaultSettings.LevelData,
                                                                       _playerCharacterDeffaultSettings.State,
                                                                       _playerCharacterDeffaultSettings.Storage,
                                                                       _playerCharacterDeffaultSettings.SkillTreeData,
                                                                       _playerCharacterDeffaultSettings.PlayerStatsContainer,
                                                                       _playerCharacterDeffaultSettings.ExperienceData);
        }
    }
}