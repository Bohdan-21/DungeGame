using Scripts.Infrastructure.SceneLoader;
using Scripts.Services.AudioService.MusicService;
using Scripts.StaticData.SystemConfigData;
using Scripts.StaticData.SystemConfigData.Audio;
using System;
using Zenject;

namespace Scripts.Infrastructure.StateMachine
{
    public class GameState : IState
    {
        private ISceneLoader _sceneLoader;
        private IBackgroundAudioPlayer _backgroundAudioPlayer;
        private GamePlayList _gamePlayList;

        private readonly ProjectGlobalSettings _projectGlobalSettings;

        public GameState(ISceneLoader sceneLoader, ProjectGlobalSettings projectGlobalSettings, 
                         IBackgroundAudioPlayer backgroundAudioPlayer, GamePlayList gamePlayList)
        {
            _sceneLoader = sceneLoader;
            _projectGlobalSettings = projectGlobalSettings;
            _backgroundAudioPlayer = backgroundAudioPlayer;
            _gamePlayList = gamePlayList;
        }

        public void Enter()
        {
            _backgroundAudioPlayer.SetPlayList(_gamePlayList);
            _backgroundAudioPlayer.StartPlayBackgroundMusic();

            _sceneLoader.LoadScene(_projectGlobalSettings.StartRoom);
        }

        public void Exit()
        {
            _backgroundAudioPlayer.StopPlayBackGroundMusic();
        }
    }
}