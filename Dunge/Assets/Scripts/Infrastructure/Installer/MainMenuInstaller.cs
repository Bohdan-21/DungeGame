using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.StateMachine;
using Scripts.Infrastructure.StateMachine.MenuStateMachine;
using Scripts.StaticData.SystemConfigData.Audio;
using Scripts.StaticData.SystemConfigData.Audio.Setup;
using Scripts.UI.License;
using Scripts.UI.MainMenu;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Installer
{
    public class MainMenuInstaller : MonoInstaller
    {
        public AudioSetupForMainMenu audioSetupForMainMenu;

        public GameObject MainMenuPrefab;
        public GameObject LicenseUI;

        public override void InstallBindings()
        {
            BindAudioSetup();

            Container.Bind<MainMenu>().FromComponentInNewPrefab(MainMenuPrefab).AsSingle();
            Container.Bind<ILicenseUI>().FromComponentInNewPrefab(LicenseUI).AsSingle();

            Container.Bind<MenuStateMachine>().AsSingle();
            Container.Bind<StartMenuState>().AsSingle();
            Container.Bind<CreateNewPlayerProgressState>().AsSingle();
            Container.Bind<LoadPlayerProgressState>().AsSingle();
        }

        private void BindAudioSetup()
        {
            Container.Bind<PlayList>().FromInstance(audioSetupForMainMenu.PlayList).AsSingle();
            Container.Bind<IBackgroundAudioPlayer>().FromComponentInNewPrefab(audioSetupForMainMenu.BackGroundAudioPlayer).AsSingle();
        }
    }
}