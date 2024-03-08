using Scripts.GameSystem.LevelGeneration.Baker;
using Scripts.Infrastructure.StateMachine;

namespace Scripts.Infrastructure.Installer.Game
{
    public class GameInstallerForGeneratedScene : GameInstaller
    {
        public LevelBaker levelBaker;

        public override void InstallBindings()
        {
            base.InstallBindings();

            BindSpecialState();

            Container.Bind<ILevelBaker>().FromInstance(levelBaker).AsSingle();
        }

        private void BindSpecialState()
        {
            Container.Bind<GenerateLevelState>().AsSingle();
        }
    }
}