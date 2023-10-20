using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.StateMachine;
using Scripts.Infrastructure.StateMachine.MenuStateMachine;
using Scripts.StaticData.Audio;
using Scripts.UI.License;
using Scripts.UI.MainMenu;
using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    public PlayList PlayList;
    public GameObject MainMenuPrefab;
    public GameObject BackGroundAudioPlayer;
    public GameObject LicenseUI;

    public override void InstallBindings()
    {
        Container.Bind<MainMenu>().FromComponentInNewPrefab(MainMenuPrefab).AsSingle();
        Container.Bind<IBackgroundAudioPlayer>().FromComponentInNewPrefab(BackGroundAudioPlayer).AsSingle();
        Container.Bind<ILicenseUI>().FromComponentInNewPrefab(LicenseUI).AsSingle();

        Container.Bind<PlayList>().FromInstance(PlayList).AsSingle();

        Container.Bind<MenuStateMachine>().AsSingle();
        Container.Bind<StartMenuState>().AsSingle();
        Container.Bind<CreateNewPlayerProgressState>().AsSingle();
        Container.Bind<LoadPlayerProgressState>().AsSingle();
    }
}