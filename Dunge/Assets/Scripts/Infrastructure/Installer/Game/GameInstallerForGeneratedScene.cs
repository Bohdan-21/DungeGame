using Scripts.GameSystem.LevelGeneration;
using Scripts.Infrastructure.StateMachine;
using Scripts.GameSystem.LevelGeneration.ConnectionStrategies;
using System;
using Scripts.GameSystem.LevelGeneration.Generation;

namespace Scripts.Infrastructure.Installer.Game
{
    public class GameInstallerForGeneratedScene : GameInstaller
    {
        public LevelCreator levelCreator;

        public override void InstallBindings()
        {
            base.InstallBindings();

            BindSpecialState();
            BindConnectionStrategies();
            BindLevelGenerator();
            BindLevelCreator();
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

        private void BindLevelGenerator()
        {
            Container.Bind<LevelGeneretion>().FromNew().AsSingle();
        }

        private void BindLevelCreator()
        {
            Container.Bind<ILevelCreator>().FromInstance(levelCreator).AsSingle();
        }

    }
}