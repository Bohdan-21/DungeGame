using Scripts.GameSystem.LevelGeneration.LevelOptimization;

namespace Scripts.Infrastructure.Installer.Game
{
    public class GameInstallerForPreparedScene : GameInstaller
    {
        public LevelDisplayOptimization Optimization;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.Bind<ILevelDisplayOptimization>().To<LevelDisplayOptimization>().FromInstance(Optimization).AsCached();
        }
    }
}