using Scripts.SaveData.SettingsData;
using Scripts.SaveData.SettingsData.ControlButton;
using Scripts.Services.SettingsService;

namespace Scripts.Services.ControlButtonService
{
    public class ControlButtonService : IControlButtonService, ISettingService
    {
        private ISettingsServiceHandler _settingsServiceHandler;

        public ControlButtonsData ControlButtons { get; private set; } = new ControlButtonsData();

        public ControlButtonService(ISettingsServiceHandler settingsServiceHandler)
        {
            _settingsServiceHandler = settingsServiceHandler;

            _settingsServiceHandler.AddService(this);
        }

        ~ControlButtonService()
        {
            _settingsServiceHandler.RemoveService(this);
        }

        public void LoadSettings(SettingsData settingsData)
        {
            ControlButtons = new ControlButtonsData(settingsData.ControlButtonsData);
        }

        public void UpdateSettings(SettingsData settingsData)
        {
            settingsData.ControlButtonsData = new ControlButtonsData(ControlButtons);
        }
    }
}
