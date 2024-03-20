namespace Scripts.Services.SettingsService
{
    public interface ISettingService
    {
        public void LoadSettings(SettingsData settingsData);

        public void UpdateSettings(SettingsData settingsData);
    }
}
