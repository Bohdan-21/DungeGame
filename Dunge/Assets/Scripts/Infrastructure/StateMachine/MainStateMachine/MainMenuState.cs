using Scripts.Infrastructure.SceneLoader;

namespace Scripts.Infrastructure.StateMachine
{
    public class MainMenuState : IState
    {
        private const string SceneName = "MainMenu";

        private ISceneLoader _sceneLoader;

        public MainMenuState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(SceneName);
        }

        public void Exit() { }
    }
}