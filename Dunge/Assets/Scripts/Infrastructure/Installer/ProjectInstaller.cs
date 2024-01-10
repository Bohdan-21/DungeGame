using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.SceneLoader;
using Scripts.Infrastructure.StateMachine;
using Scripts.Services.AudioService;
using Scripts.Services.InputService;
using Scripts.Services.PlayerProgressService;
using Scripts.Services.SaveLoad;
using Scripts.StaticData.Audio;
using Scripts.StaticData.ControlButton;
using Scripts.StaticData.EnemyStaticData;
using Scripts.StaticData.EnumLinks;
using Scripts.StaticData.GameStaticData;
using Scripts.StaticData.ItemStaticData;
using Scripts.StaticData.NPCStaticData;
using Scripts.StaticData.PlayerStaticData;
using Scripts.StaticData.ProjectGlobalSettings;
using Scripts.UI.Curtain;
using Scripts.UI.Settings;
using System;
using UnityEngine;
using Zenject;
using Scripts.LanguageLocalization.Service;

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
        public PlayerCharacterDeffaultSettings PlayerCharacterDefaultSettings;

        public EnemyStaticData EnemyStaticData;
        public EnemyCharacterDeffaultSettings EnemyCharacterDeffaultSettings;

        public ListEnumLinksFromStatToAttribute staticDataFromStatToAtrribute;
        public ListEnumLinksFromAttributeToSkill staticDataFromAttributeToSkill;

        public NPCStaticData NPCStaticData;

        public ItemCollection ItemsStaticData;

        public ExperienceForKilledMonster ExperienceForKilledMonster;

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
            Container.Bind<PlayerCharacterDeffaultSettings>().FromInstance(PlayerCharacterDefaultSettings).AsSingle();

            Container.Bind<EnemyStaticData>().FromInstance(EnemyStaticData).AsSingle();
            Container.Bind<EnemyCharacterDeffaultSettings>().FromInstance(EnemyCharacterDeffaultSettings).AsSingle();

            Container.Bind<ListEnumLinksFromStatToAttribute>().FromInstance(staticDataFromStatToAtrribute).AsSingle();
            Container.Bind<ListEnumLinksFromAttributeToSkill>().FromInstance(staticDataFromAttributeToSkill).AsSingle();

            Container.Bind<NPCStaticData>().FromInstance(NPCStaticData).AsSingle();

            Container.Bind<ItemCollection>().FromInstance(ItemsStaticData).AsSingle();

            Container.Bind<ExperienceForKilledMonster>().FromInstance(ExperienceForKilledMonster).AsSingle();
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