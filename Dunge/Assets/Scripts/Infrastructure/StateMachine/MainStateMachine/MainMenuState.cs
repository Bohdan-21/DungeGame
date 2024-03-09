using Scripts.Infrastructure.SceneLoader;
using Scripts.UI.Curtain;

namespace Scripts.Infrastructure.StateMachine
{
    public class MainMenuState : IState
    {
        private const string SceneName = "MainMenu";

        private ISceneLoader _sceneLoader;
        private ICurtain _curtain;

        public MainMenuState(ISceneLoader sceneLoader, ICurtain curtain)
        {
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(SceneName, SceneHasBeenLoaded);
        }

        private void SceneHasBeenLoaded()
        {
            _curtain.Hide();
        }

        public void Exit() { }
    }
}