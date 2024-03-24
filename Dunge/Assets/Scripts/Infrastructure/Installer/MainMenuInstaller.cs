using Scripts.Infrastructure.StateMachine.MenuStateMachine;
using Scripts.UI.License;
using Scripts.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Installer
{
    public class MainMenuInstaller : MonoInstaller
    {
        public GameObject MainMenuPrefab;
        public GameObject LicenseUI;

        public override void InstallBindings()
        {
            Container.Bind<MainMenu>().FromComponentInNewPrefab(MainMenuPrefab).AsSingle();
            Container.Bind<ILicenseUI>().FromComponentInNewPrefab(LicenseUI).AsSingle();

            Container.Bind<MenuStateMachine>().AsSingle();
            Container.Bind<StartMenuState>().AsSingle();
            Container.Bind<CreateNewPlayerProgressState>().AsSingle();
            Container.Bind<LoadPlayerProgressState>().AsSingle();
        }
    }
}