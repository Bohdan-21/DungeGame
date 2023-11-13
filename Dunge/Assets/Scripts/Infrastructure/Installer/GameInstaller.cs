using Scripts.DialogSystem.Logic;
using Scripts.DialogSystem.Logic.UIController;
using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.StateMachine;
using Scripts.Level;
using Scripts.QuestSystem;
using Scripts.QuestSystem.Channel;
using Scripts.QuestSystem.UI;
using Scripts.Services.InteruptService;
using Scripts.StaticData.Audio;
using Scripts.StaticData.Audio.Setup;
using Scripts.StaticData.Dialog;
using Scripts.StaticData.QuestStaticData;
using Scripts.StaticData.QuestStaticData.Setup;
using Scripts.UI.Interaction;
using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public AudioSetupForGame audioSetupForGame;
    public DialogSetupSystem dialogSetupSystem;
    public QuestSetup questSetup;

    public LevelSettings LevelSettings;

    public override void InstallBindings()
    {
        BindAudioSetup();
        BindGameFactory();
        BindQuestSystem();
        BindDialogSetup();
        BindLevelSettings();
        BindInteruptService();
        BindGameStateMachine();
    }

    private void BindGameFactory()
    {
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
    }

    private void BindDialogSetup()
    {
        Container.Bind<IDialogTracking>().To<DialogTracking>().AsSingle();
        Container.Bind<IDialogInitializer>().To<DialogInitializer>().AsSingle();
        Container.Bind<IDialogUI>().FromComponentInNewPrefab(dialogSetupSystem.DialogUIPrefab).AsSingle();
        Container.Bind<IInteractionPanel>().FromComponentInNewPrefab(dialogSetupSystem.InteractionPanerPrefab).AsSingle();
    }

    private void BindQuestSystem()
    {
        Container.Bind<QuestJournal>().FromNew().AsSingle();
        Container.Bind<QuestMachine>().FromNew().AsSingle();
        Container.Bind<QuestList>().FromInstance(questSetup.questList).AsSingle();
        Container.Bind<IQuestJournalUI>().FromComponentInNewPrefab(questSetup.questJournalUI).AsSingle().NonLazy();

        Container.Bind<QuestChannel>().FromNew().AsSingle();
        Container.Bind<CombatChannel>().FromNew().AsSingle();
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

    private void BindAudioSetup()
    {
        BindBackgroundAudioPlayer();
        BindSoundGameActionPlayer();
    }

    private void BindBackgroundAudioPlayer()
    {
        Container.Bind<PlayList>().FromInstance(audioSetupForGame.playList).AsSingle();
        Container.Bind<IBackgroundAudioPlayer>().FromComponentInNewPrefab(audioSetupForGame.BackgroundAudioPlayer).AsSingle();
    }

    private void BindSoundGameActionPlayer()
    {
        Container.Bind<SoundListForGameAction>().FromInstance(audioSetupForGame.SoundList).AsSingle();
        Container.Bind<ISoundsGameActionPlayer>().FromComponentInNewPrefab(audioSetupForGame.SoundGameActionPlayerPrefab).AsSingle();
    }
}