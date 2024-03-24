using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.SceneLoader;
using Scripts.Infrastructure.StateMachine;
using Scripts.Services.AudioService;
using Scripts.Services.InputService;
using Scripts.Services.PlayerProgressService;
using Scripts.UI.Curtain;
using Scripts.UI.Settings;
using UnityEngine;
using Zenject;
using Scripts.StaticData.SystemConfigData.Audio;
using Scripts.StaticData.GameConfigData.Player;
using Scripts.StaticData.GameConfigData.Enemy;
using Scripts.StaticData.GameConfigData.Enemy.Experience;
using Scripts.StaticData.GameConfigData.Enemy.Config;
using Scripts.StaticData.SystemConfigData;
using Scripts.StaticData.GameConfigData.NPC;
using Scripts.StaticData.GameConfigData.Item;
using Scripts.StaticData.GameConfigData.GameSystem.SkillTree.EnumLinks;
using Scripts.StaticData;
using Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForItem;
using Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForSkillTree;
using Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForStat;
using Assets.Scripts.StaticData.GameConfigData.Environment;
using Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration.Setup;
using Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration;
using Scripts.Services.SettingsService;
using Scripts.Services.ControlButtonService;
using Scripts.Services.LanguageService;
using Scripts.Services.SaveLoadServices.Player;
using Scripts.Services.SaveLoadServices.GameSettings;
using Scripts.StaticData.SystemConfigData.Settings;

namespace Scripts.Infrastructure.Installer
{
    public class ProjectInstaller : MonoInstaller
    {
        public GameObject CurtainPrefab;
        public GameObject SettingsUIPrefab;
        public GameObject SceneLoaderPrefab;
        public GameObject SoundButtonActionPlayerPrefab;

        public DefaultGameSettings DeffaultSettings;

        public SoundListForGameAction SoundListForGameAction;
        public SoundListForButtonAction SoundListForButtonAction;

        public GameStaticData GameStaticData;

        public EnvironmentData EnvironmentData;

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

        public ChunkSetup chunkSetup;
        public ChunksForGenerationLevel chunks;

        public override void InstallBindings()
        {
            BindGameSettings();

            BindInput();

            BindChunkData();
            
            BindSettingsUI();

            BindStaticData();

            BindSceneLoader();

            BindPlayerProgress();

            BindSaveLoadService();

            BindMainStateMachine();

            BindSoundButtonActionPlayer();
        }

        private void BindGameSettings()
        {
            Container.Bind<DefaultGameSettings>().FromInstance(DeffaultSettings).AsSingle();

            Container.Bind<IAudioService>().To<AudioService>().FromNew().AsSingle().NonLazy();
            Container.Bind<IControlButtonService>().To<ControlButtonService>().AsSingle().NonLazy();
            Container.Bind<ILanguageService>().To<LanguageService>().FromNew().AsSingle().NonLazy();

            Container.Bind<ISaveLoadSettingsService>().To<SaveLoadSettingsService>().FromNew().AsSingle();
            Container.Bind<ISettingsServiceHandler>().To<SettingsServiceHandler>().FromNew().AsSingle();
        }

        private void BindInput()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }

        private void BindChunkData()
        {
            Container.Bind<ChunkSetup>().FromInstance(chunkSetup).AsSingle();
            Container.Bind<ChunksForGenerationLevel>().FromInstance(chunks).AsSingle();
        }

        private void BindSettingsUI()
        {
            Container.Bind<ISettingsUI>().FromComponentInNewPrefab(SettingsUIPrefab).AsSingle();
        }

        private void BindStaticData()
        {
            Container.Bind<SoundListForGameAction>().FromInstance(SoundListForGameAction).AsSingle();
            Container.Bind<SoundListForButtonAction>().FromInstance(SoundListForButtonAction).AsSingle();



            Container.Bind<GameStaticData>().FromInstance(GameStaticData).AsSingle();

            Container.Bind<EnvironmentData>().FromInstance(EnvironmentData).AsSingle();

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
            Container.Bind<ISceneLoader>().To<SceneLoader.SceneLoader>().FromComponentInNewPrefab(SceneLoaderPrefab).AsSingle();
        }

        private void BindPlayerProgress()
        {
            Container.Bind<IPlayerProgressService>().To<PlayerProgressService>().AsSingle();
        }

        private void BindSaveLoadService()
        {
            Container.Bind<IPlayerProgressSaveLoadService>().To<PlayerProgressSaveLoadService>().AsSingle();
        }

        private void BindMainStateMachine()
        {
            Container.Bind<MainStateMachine>().AsSingle();

            Container.Bind<LoadSettingsState>().AsSingle();
            Container.Bind<MainMenuState>().AsSingle();
            Container.Bind<GameState>().AsSingle();
            Container.Bind<ExitApplicationState>().AsSingle();
        }

        private void BindSoundButtonActionPlayer()
        {
            Container.Bind<ISoundsButtonActionPlayer>().FromComponentInNewPrefab(SoundButtonActionPlayerPrefab).AsSingle();
        }
    }
}