using Scripts.GameSystem.LevelGeneration;
using Scripts.Infrastructure.StateMachine;
using Scripts.GameSystem.LevelGeneration.ConnectionStrategies;
using System;
using Scripts.GameSystem.LevelGeneration.LevelOptimization;
using Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration.Setup;
using Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration;

namespace Scripts.Infrastructure.Installer.Game
{
    public class GameInstallerForGeneratedScene : GameInstaller
    {
        public LevelCreator levelCreator;
        public LevelDisplayOptimization Optimization;

        public override void InstallBindings()
        {
            base.InstallBindings();
            Container.Bind<ILevelDisplayOptimization>().To<LevelDisplayOptimization>().FromInstance(Optimization).AsCached();
            BindLevelCreator();
            BindSpecialState();
            BindConnectionStrategies();
            BindLevelDisplayOptimization();
        }


        private void BindLevelCreator()
        {
            Container.Bind<ILevelCreator>().FromInstance(levelCreator).AsSingle();
        }

        private void BindSpecialState()
        {
            Container.Bind<GenerateLevelState>().AsSingle();
        }

        private void BindConnectionStrategies()
        {
            Container.Bind<ConnectionStrategyFactory>().AsSingle();

            Container.Bind<TurnableConnectionStrategy>().AsSingle();
            Container.Bind<ForwardConnectionStrategy>().AsSingle();
            Container.Bind<ForkThreePointConnectionStrategy>().AsSingle();
            Container.Bind<ForkFourPointConnectionStrategy>().AsSingle();
            Container.Bind<DeadEndConnectionStrategy>().AsSingle();
        }

        private void BindLevelDisplayOptimization()
        {
            Container.Bind<LevelDisplayOptimization>().AsSingle();
        }
    }
}