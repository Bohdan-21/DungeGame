using Scripts.GameSystem.LevelGeneration;
using Scripts.Infrastructure.StateMachine;

namespace Scripts.Infrastructure.Installer.Game
{
    public class GameInstallerForGeneratedScene : GameInstaller
    {
        public LevelCreator levelCreator;

        public override void InstallBindings()
        {
            base.InstallBindings();

            BindSpecialState();

            Container.Bind<ILevelCreator>().FromInstance(levelCreator).AsSingle();
        }

        private void BindSpecialState()
        {
            Container.Bind<GenerateLevelState>().AsSingle();
        }
    }
}