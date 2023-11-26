using Scripts.GameSystem.DialogSystem.Logic;
using Scripts.GameSystem.DialogSystem.Logic.UIController;
using Scripts.GameSystem.QuestSystem.Channel;
using Scripts.GameSystem.QuestSystem.Factory;
using Scripts.GameSystem.QuestSystem.Journal;
using Scripts.GameSystem.QuestSystem.UI.QuestJournal;
using Scripts.GameSystem.QuestSystem.UI.Tracker;
using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.StateMachine;
using Scripts.Level;
using Scripts.Services.InteruptService;
using Scripts.StaticData.Audio;
using Scripts.StaticData.Audio.Setup;
using Scripts.StaticData.Dialog.Setup;
using Scripts.StaticData.QuestStaticData;
using Scripts.StaticData.QuestStaticData.Setup;
using Scripts.UI.Interaction;
using Scripts.UI.NameLocation;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public AudioSetupForGame audioSetupForGame;
    public DialogSetupSystem dialogSetupSystem;
    public QuestSetup questSetup;

    public GameObject LocationNameUI;

    public LevelSettings LevelSettings;

    public override void InstallBindings()
    {
        Container.Bind<INameLocationUI>().FromComponentInNewPrefab(LocationNameUI).AsSingle().NonLazy();

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
        Container.Bind<QuestFactory>().FromNew().AsSingle();
        Container.Bind<QuestList>().FromInstance(questSetup.questList).AsSingle();
        Container.Bind<IQuestJournal>().FromComponentInNewPrefab(questSetup.questJournal).AsSingle();
        Container.Bind<IQuestJournalUI>().FromComponentInNewPrefab(questSetup.questJournalUI).AsSingle().NonLazy();
        Container.Bind<IQuestTracker>().FromComponentInNewPrefab(questSetup.questTrackerUI).AsSingle().NonLazy();

        Container.Bind<QuestChannel>().FromNew().AsSingle();
        Container.Bind<CombatChannel>().FromNew().AsSingle();
        Container.Bind<DialogChannel>().FromNew().AsSingle();
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