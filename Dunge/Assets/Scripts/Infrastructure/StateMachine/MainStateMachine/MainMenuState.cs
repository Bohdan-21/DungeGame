using Scripts.Infrastructure.SceneLoader;
using Scripts.Services.AudioService.MusicService;
using Scripts.StaticData.SystemConfigData.Audio;
using Scripts.UI.Curtain;

namespace Scripts.Infrastructure.StateMachine
{
    public class MainMenuState : IState
    {
        private const string SceneName = "MainMenu";

        private ISceneLoader _sceneLoader;
        private ICurtain _curtain;
        private IBackgroundAudioPlayer _backgroundAudioPlayer;
        private MenuPlayList _menuPlayList;

        public MainMenuState(ISceneLoader sceneLoader, ICurtain curtain, IBackgroundAudioPlayer backgroundAudioPlayer, 
                             MenuPlayList menuPlayList)
        {
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _backgroundAudioPlayer = backgroundAudioPlayer;
            _menuPlayList = menuPlayList;
        }

        public void Enter()
        {
            _backgroundAudioPlayer.SetPlayList(_menuPlayList);
            _backgroundAudioPlayer.StartPlayBackgroundMusic();

            _sceneLoader.LoadScene(SceneName, SceneHasBeenLoaded);
        }

        private void SceneHasBeenLoaded()
        {
            _curtain.Hide();
        }

        public void Exit() 
        {
            _backgroundAudioPlayer.StopPlayBackGroundMusic();
        }
    }
}