using Scripts.DialogSystem.Logic;
using Scripts.DialogSystem.Logic.UIController;
using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.StateMachine;
using Scripts.Level;
using Scripts.Services.InteruptService;
using Scripts.StaticData.Audio;
using Scripts.UI.GamePause;
using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public PlayList PlayList;
    public GameObject BackgroundAudioPlayer;

    public SoundListForGameAction SoundList;
    public GameObject SoundGameActionPlayerPrefab;

    public LevelSettings LevelSettings;

    public GameObject DialogUIPrefab;
    public GameObject DialogTrackerPrefab;
    public GameObject DialogInitializerPrefab;


    public override void InstallBindings()
    {
        BindGameFactory();
        BindDialogSystem();
        BindLevelSettings();
        BindInteruptService();
        BindGameStateMachine();
        BindBackgroundAudioPlayer();
        BindSoundGameActionPlayer();
    }

    private void BindGameFactory()
    {
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
    }

    private void BindDialogSystem()
    {
        Container.Bind<IDialogUI>().FromComponentInNewPrefab(DialogUIPrefab).AsSingle();
        Container.Bind<IDialogTracking>().FromComponentInNewPrefab(DialogTrackerPrefab).AsSingle();
        Container.Bind<IDialogInitializer>().FromComponentInNewPrefab(DialogInitializerPrefab).AsSingle();
    }

    private void BindLevelSettings()
    {
        Container.Bind<LevelSettings>().FromInstance(LevelSettings);
    }

    private void BindInteruptService()
    {
        Container.Bind<IInteruptService>().To<InteruptService>().AsSingle();
    }

    private void BindGameStateMachine()
    {
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<ReloadLevelState>().AsSingle();
        Container.Bind<InitializeLevelState>().AsSingle();
        Container.Bind<GameLoopState>().AsSingle();
        Container.Bind<DeathState>().AsSingle();
        Container.Bind<QuitState>().AsSingle();
        Container.Bind<WinState>().AsSingle();
    }

    private void BindBackgroundAudioPlayer()
    {
        Container.Bind<PlayList>().FromInstance(PlayList).AsSingle();
        Container.Bind<IBackgroundAudioPlayer>().FromComponentInNewPrefab(BackgroundAudioPlayer).AsSingle();
    }

    private void BindSoundGameActionPlayer()
    {
        Container.Bind<SoundListForGameAction>().FromInstance(SoundList).AsSingle();
        Container.Bind<ISoundsGameActionPlayer>().FromComponentInNewPrefab(SoundGameActionPlayerPrefab).AsSingle();
    }
}