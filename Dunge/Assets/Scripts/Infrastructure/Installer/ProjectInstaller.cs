using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.SceneLoader;
using Scripts.Infrastructure.StateMachine;
using Scripts.Services.AudioService;
using Scripts.Services.InputService;
using Scripts.Services.PlayerProgressService;
using Scripts.Services.SaveLoad;
using Scripts.UI.Curtain;
using Scripts.UI.Settings;
using System;
using UnityEngine;
using Zenject;
using Scripts.LanguageLocalization.Service;
using Scripts.StaticData.SystemConfigData.Audio;
using Scripts.StaticData.GameConfigData.Player;
using Scripts.StaticData.GameConfigData.Enemy;
using Scripts.StaticData.GameConfigData.Enemy.Experience;
using Scripts.StaticData.GameConfigData.Enemy.Config;
using Scripts.StaticData.SystemConfigData.ControlButton;
using Scripts.StaticData.SystemConfigData;
using Scripts.StaticData.GameConfigData.NPC;
using Scripts.StaticData.GameConfigData.Item;
using Scripts.StaticData.GameConfigData.GameSystem.SkillTree.EnumLinks;
using Scripts.StaticData;
using Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForItem;
using Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForSkillTree;
using Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForStat;

namespace Scripts.Installer
{
    public class ProjectInstaller : MonoInstaller
    {
        public GameObject CurtainPrefab;
        public GameObject SettingsUIPrefab;
        public GameObject SceneLoaderPrefab;
        public GameObject SoundButtonActionPlayerPrefab;

        public AudioSetting AudioSetting;
        public SoundListForGameAction SoundListForGameAction;
        public SoundListForButtonAction SoundListForButtonAction;

        public ControlButtons ControlButtons;

        public GameStaticData GameStaticData;
        public ProjectGlobalSettings ProjectGlobalSettings;
        public PlayerCharacterConfig PlayerCharacterConfig;
        public PlayerCharacterSettingsForNewGame PlayerCharacterDefaultSettings;

        public EnemyCharacterConfig EnemyStaticData;
        public DeffaultSettingsForNewEnemy EnemyCharacterDeffaultSettings;

        public ListEnumLinksFromStatToAttribute staticDataFromStatToAtrribute;
        public ListEnumLinksFromAttributeToSkill staticDataFromAttributeToSkill;

        public NPCPrefabReference NPCStaticData;

        public ItemCollection ItemsStaticData;

        public ExperienceForKilledEnemy ExperienceForKilledMonster;

        public LocalizationForItemType LocalizationForItemType;
        public LocalizationForStatType LocalizationForStatType;
        public LocalizationForSkillType LocalizationForSkillType;
        public LocalizationForAttributeType LocalizationForAttributeType;

        public override void InstallBindings()
        {
            BindInput();

            BindSettingsUI();

            BindStaticData();

            BindSceneLoader();

            BindAudioService();

            BindPlayerProgress();

            BindSaveLoadService();

            BindLanguageSettings();

            BindMainStateMachine();

            BindSoundButtonActionPlayer();
        }

        private void BindInput()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }

        private void BindSettingsUI()
        {
            Container.Bind<ISettingsUI>().FromComponentInNewPrefab(SettingsUIPrefab).AsSingle();
        }

        private void BindStaticData()
        {
            Container.Bind<AudioSetting>().FromInstance(AudioSetting).AsSingle();
            Container.Bind<SoundListForGameAction>().FromInstance(SoundListForGameAction).AsSingle();
            Container.Bind<SoundListForButtonAction>().FromInstance(SoundListForButtonAction).AsSingle();

            Container.Bind<ControlButtons>().FromInstance(ControlButtons).AsSingle();

            Container.Bind<GameStaticData>().FromInstance(GameStaticData).AsSingle();
            Container.Bind<ProjectGlobalSettings>().FromInstance(ProjectGlobalSettings).AsSingle();
            Container.Bind<PlayerCharacterConfig>().FromInstance(PlayerCharacterConfig).AsSingle();
            Container.Bind<PlayerCharacterSettingsForNewGame>().FromInstance(PlayerCharacterDefaultSettings).AsSingle();

            Container.Bind<EnemyCharacterConfig>().FromInstance(EnemyStaticData).AsSingle();
            Container.Bind<DeffaultSettingsForNewEnemy>().FromInstance(EnemyCharacterDeffaultSettings).AsSingle();

            Container.Bind<ListEnumLinksFromStatToAttribute>().FromInstance(staticDataFromStatToAtrribute).AsSingle();
            Container.Bind<ListEnumLinksFromAttributeToSkill>().FromInstance(staticDataFromAttributeToSkill).AsSingle();

            Container.Bind<NPCPrefabReference>().FromInstance(NPCStaticData).AsSingle();

            Container.Bind<ItemCollection>().FromInstance(ItemsStaticData).AsSingle();

            Container.Bind<ExperienceForKilledEnemy>().FromInstance(ExperienceForKilledMonster).AsSingle();

            Container.Bind<LocalizationForItemType>().FromInstance(LocalizationForItemType).AsSingle();
            Container.Bind<LocalizationForStatType>().FromInstance(LocalizationForStatType).AsSingle();
            Container.Bind<LocalizationForSkillType>().FromInstance(LocalizationForSkillType).AsSingle();
            Container.Bind<LocalizationForAttributeType>().FromInstance(LocalizationForAttributeType).AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ICurtain>().To<Curtain>().FromComponentInNewPrefab(CurtainPrefab).AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().FromComponentInNewPrefab(SceneLoaderPrefab).AsSingle();
        }

        private void BindAudioService()
        {
            Container.Bind<IAudioService>().To<AudioService>().FromNew().AsSingle();
        }

        private void BindPlayerProgress()
        {
            Container.Bind<IPlayerProgressService>().To<PlayerProgressService>().AsSingle();
        }

        private void BindSaveLoadService()
        {
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
        }

        private void BindLanguageSettings()
        {
            Container.Bind<ILanguageSettings>().To<LanguageSettings>().FromNew().AsSingle();
        }

        private void BindMainStateMachine()
        {
            Container.Bind<MainStateMachine>().AsSingle();
            Container.Bind<MainMenuState>().AsSingle();
            Container.Bind<GameState>().AsSingle();
        }

        private void BindSoundButtonActionPlayer()
        {
            Container.Bind<ISoundsButtonActionPlayer>().FromComponentInNewPrefab(SoundButtonActionPlayerPrefab).AsSingle();
        }
    }
}