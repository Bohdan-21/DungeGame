using Scripts.Infrastructure.SceneLoader;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.SystemConfigData;
using System;

namespace Scripts.Infrastructure.StateMachine
{
    public class ReloadLevelState : IState
    {
        private ISceneLoader _sceneLoader;
        private readonly IPlayerProgressService _progressService;
        private readonly ProjectGlobalSettings _projectGlobalSettings;

        public ReloadLevelState(ISceneLoader sceneLoader, IPlayerProgressService progressService,
            ProjectGlobalSettings projectGlobalSettings)
        {
            _sceneLoader = sceneLoader;
            _progressService = progressService;
            _projectGlobalSettings = projectGlobalSettings;
        }

        public void Enter()
        {
            string nameCurrentDungeLevelScene = GetNameCurrentDungeLevel();

            _sceneLoader.LoadScene(nameCurrentDungeLevelScene);
        }

        private string GetNameCurrentDungeLevel()
        {
            return _progressService.PlayerProgress.LevelData.NextLoadRoom;
        }

        public void Exit()
        {
            
        }
    }
}
