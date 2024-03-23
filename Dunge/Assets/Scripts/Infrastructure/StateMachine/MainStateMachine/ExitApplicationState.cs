using Scripts.Services.SettingsService;
using UnityEngine;

namespace Scripts.Infrastructure.StateMachine
{
    public class ExitApplicationState : IState
    {
        private ISettingsServiceHandler _settingsServiceHandler;
        private ISaveLoadSettingsService _saveLoadSettings;

        public ExitApplicationState(ISettingsServiceHandler settingsServiceHandler, ISaveLoadSettingsService saveLoadSettings)
        {
            _settingsServiceHandler = settingsServiceHandler;
            _saveLoadSettings = saveLoadSettings;
        }

        public void Enter()
        {
            _settingsServiceHandler.AllertAllUpdateSettings();

            _saveLoadSettings.Save(_settingsServiceHandler.SettingsData);

            Application.Quit();
        }

        public void Exit()
        {
            Debug.Log("Настройки сохраненны.");
        }
    }
}