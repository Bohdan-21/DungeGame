using Scripts.Infrastructure.StateMachine;
using UnityEngine;

namespace Scripts.Infrastructure.Installer.Game
{
    public class GameInstallerForGeneratedScene : GameInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            BindSpecialState();
        }

        private void BindSpecialState()
        {
            Container.Bind<GenerateLevelState>().AsSingle();
        }
    }
}