using Scripts.GameSystem.DialogSystem.Logic;
using Scripts.GameSystem.DialogSystem.Logic.UIController;
using Scripts.GameSystem.LevelGeneration.Grid;
using Scripts.GameSystem.LevelGeneration.LevelOptimization;
using Scripts.GameSystem.LevelGeneration.LevelSetting;
using Scripts.GameSystem.QuestSystem.Channel;
using Scripts.GameSystem.QuestSystem.Factory;
using Scripts.GameSystem.QuestSystem.Journal;
using Scripts.GameSystem.QuestSystem.UI.QuestJournal;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.Logic;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.StateMachine;
using Scripts.Services.AudioService.SoundService;
using Scripts.Services.InteruptService;
using Scripts.StaticData.GameConfigData.GameSystem.Dialog.Setup;
using Scripts.StaticData.GameConfigData.GameSystem.QuestStaticData;
using Scripts.StaticData.GameConfigData.GameSystem.QuestStaticData.Setup;
using Scripts.StaticData.SystemConfigData.Audio;
using Scripts.StaticData.SystemConfigData.Audio.Setup;
using Scripts.UI.Interaction;
using Scripts.UI.NameLocation;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Installer.Game
{
    public class GameInstaller : MonoInstaller
    {
        public GameObject GameCamera;

        public AudioSetupForGame audioSetupForGame;
        public DialogSetupSystem dialogSetupSystem;
        public QuestSetup questSetup;

        public GameObject TradingSystemUI;

        public GameObject LocationNameUI;

        public LevelData LevelSettings;

        public LevelDisplayOptimization Optimization;

        public override void InstallBindings()
        {
            BindLevelHandler();
            BindGameCamera();
            BindGameSound();
            BindGameFactory();
            BindQuestSystem();
            BindDialogSetup();
            BindTradingSystem();
            BindNameLocation();
            BindInteruptService();
            BindGameStateMachine();
        }

        private void BindLevelHandler()
        {
            Container.Bind<LevelData>().FromInstance(LevelSettings);
            Container.Bind<LevelGrid>().FromNew().AsSingle();
            Container.Bind<ILevelDisplayOptimization>().To<LevelDisplayOptimization>().FromInstance(Optimization).AsSingle();
        }

        private void BindGameCamera()
        {
            Container.Bind<ICameraFollow>().To<CameraFollow>().FromComponentInNewPrefab(GameCamera).AsSingle().NonLazy();
        }

        private void BindGameSound()
        {
            Container.Bind<SoundListForGameAction>().FromInstance(audioSetupForGame.SoundList).AsSingle();
            Container.Bind<ISoundsGameActionPlayer>().FromComponentInNewPrefab(audioSetupForGame.SoundGameActionPlayerPrefab).AsSingle();
        }
        
        private void BindDialogSetup()
        {
            Container.Bind<IDialogTracking>().To<DialogTracking>().AsSingle();
            Container.Bind<IDialogInitializer>().To<DialogInitializer>().AsSingle();
            Container.Bind<IDialogUI>().FromComponentInNewPrefab(dialogSetupSystem.DialogUIPrefab).AsSingle();
            Container.Bind<IInteractionPanel>().FromComponentInNewPrefab(dialogSetupSystem.InteractionPanerPrefab).AsSingle();
        }

        private void BindGameFactory()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
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

        private void BindInteruptService()
        {
            Container.Bind<IInteruptService>().To<InteruptService>().AsSingle();
        }

        private void BindNameLocation()
        {
            Container.Bind<INameLocationUI>().FromComponentInNewPrefab(LocationNameUI).AsSingle().NonLazy();
        }

        private void BindQuestSystem()
        {
            Container.Bind<QuestFactory>().FromNew().AsSingle();
            Container.Bind<QuestList>().FromInstance(questSetup.questList).AsSingle();
            Container.Bind<IQuestJournal>().FromComponentInNewPrefab(questSetup.questJournal).AsSingle();
            Container.Bind<IQuestJournalUI>().FromComponentInNewPrefab(questSetup.questJournalUI).AsSingle().NonLazy();
            //Container.Bind<IQuestTracker>().FromComponentInNewPrefab(questSetup.questTrackerUI).AsSingle().NonLazy();
            //TODO: for activate QUEST_TRACKER uncomment this

            Container.Bind<QuestChannel>().FromNew().AsSingle();
            Container.Bind<CombatChannel>().FromNew().AsSingle();
            Container.Bind<DialogChannel>().FromNew().AsSingle();
        }

        private void BindTradingSystem()
        {
            Container.Bind<TradingOperation>().FromNew().AsSingle().NonLazy();
            Container.Bind<ITraiderUI>().FromComponentInNewPrefab(TradingSystemUI).AsSingle().NonLazy();
        }
    }
}