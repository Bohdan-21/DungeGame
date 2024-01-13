using Scripts.Infrastructure.SceneLoader;
using Scripts.StaticData.SystemConfigData;
using System;
using Zenject;

namespace Scripts.Infrastructure.StateMachine
{
    public class GameState : IState
    {
        private ISceneLoader _sceneLoader;
        private readonly ProjectGlobalSettings _projectGlobalSettings;

        public GameState(ISceneLoader sceneLoader, ProjectGlobalSettings projectGlobalSettings)
        {
            _sceneLoader = sceneLoader;
            _projectGlobalSettings = projectGlobalSettings;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(_projectGlobalSettings.StartRoom);
        }

        public void Exit() { }
    }

}