using Scripts.Infrastructure.StateMachine;
using Scripts.Infrastructure.StateMachine.MenuStateMachine;
using Scripts.Services.AudioService.SoundService;
using Scripts.UI.License;
using Scripts.UI.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.UI.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        private ISoundsButtonActionPlayer _soundsButtonActionPlayer;
        private MenuStateMachine _menuStateMachine;
        private MainStateMachine _mainStateMachine;
        private ISettingsUI _settingsUI;
        private ILicenseUI _licenseUI;
        public GameObject rootComponent;

        [Inject]
        private void Construct(ISoundsButtonActionPlayer soundsButtonActionPlayer, MenuStateMachine menuStateMachine, 
                               MainStateMachine mainStateMachine, ISettingsUI settingsUI, ILicenseUI licenseUI)
        {
            _soundsButtonActionPlayer = soundsButtonActionPlayer;
            _menuStateMachine = menuStateMachine;
            _mainStateMachine = mainStateMachine;
            _settingsUI = settingsUI;
            _licenseUI = licenseUI;
        }

        public void ClickNewGame()
        {
            PlaySoundButtonPress();

            _menuStateMachine.Enter<CreateNewPlayerProgressState>();
        }

        public void ClickLoadGame()
        {
            PlaySoundButtonPress();

            _menuStateMachine.Enter<LoadPlayerProgressState>();
        }

        public void ClickSettings()
        {
            PlaySoundButtonPress();

            _settingsUI.Show();
        }

        public void ClickLicense()
        {
            PlaySoundButtonPress();

            _licenseUI.Show();
        }

        public void ClickExit()
        {
            PlaySoundButtonPress();

            _mainStateMachine.Enter<ExitApplicationState>();
        }

        private void PlaySoundButtonPress() =>
            _soundsButtonActionPlayer.PlayButtonPressSound();

        public void Show() =>
            rootComponent.SetActive(true);

        public void Hide() =>
            rootComponent.SetActive(false);
    }
}