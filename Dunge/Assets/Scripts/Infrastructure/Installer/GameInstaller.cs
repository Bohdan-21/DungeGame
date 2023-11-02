using Scripts.DialogSystem.Logic;
using Scripts.DialogSystem.Logic.UIController;
using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.StateMachine;
using Scripts.Level;
using Scripts.Services.InteruptService;
using Scripts.StaticData.Audio;
using Scripts.UI.GamePause;
using Scripts.UI.Interaction;
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
    public GameObject InteractionPanerPrefab;

    public override void InstallBindings()
    {
        BindGameFactory();
        BindDialogSystem();
        BindLevelSettings();
        BindInteruptService();
        BindInteractionPanel();
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
        Container.Bind<IDialogTracking>().To<DialogTracking>().AsSingle();
        Container.Bind<IDialogInitializer>().To<DialogInitializer>().AsSingle();
        Container.Bind<IDialogUI>().FromComponentInNewPrefab(DialogUIPrefab).AsSingle();
    }

    private void BindLevelSettings()
    {
        Container.Bind<LevelSettings>().FromInstance(LevelSettings);
    }

    private void BindInteruptService()
    {
        Container.Bind<IInteruptService>().To<InteruptService>().AsSingle();
    }

    private void BindInteractionPanel()
    {
        Container.Bind<IInteractionPanel>().FromComponentInNewPrefab(InteractionPanerPrefab).AsSingle();
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