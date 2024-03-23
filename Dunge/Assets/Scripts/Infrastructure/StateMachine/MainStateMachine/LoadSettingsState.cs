using Scripts.Services.SettingsService;
using UnityEngine;

namespace Scripts.Infrastructure.StateMachine
{
    public class LoadSettingsState : IState
    {
        private ISettingsServiceHandler _settingsServiceHandler;
        private ISaveLoadSettingsService _saveLoadSettings;
        private DeffaultSettings _deffaultSettings;
        private MainStateMachine _mainStateMachine;

        public LoadSettingsState(ISettingsServiceHandler settingsServiceHandler, ISaveLoadSettingsService saveLoadSettings, 
                                 DeffaultSettings deffaultSettings, MainStateMachine mainStateMachine)
        {
            _settingsServiceHandler = settingsServiceHandler;
            _saveLoadSettings = saveLoadSettings;
            _deffaultSettings = deffaultSettings;
            _mainStateMachine = mainStateMachine;
        }

        public void Enter()
        {
            _settingsServiceHandler.SettingsData = _saveLoadSettings.Load() ?? _deffaultSettings.settingsData;

            _settingsServiceHandler.AllertAllLoadSettings();

            _mainStateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {
            Debug.Log("Настройки были загруженны.");
        }
    }
}