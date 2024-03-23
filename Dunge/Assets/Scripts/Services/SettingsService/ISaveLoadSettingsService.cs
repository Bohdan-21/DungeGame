namespace Scripts.Services.SettingsService
{
    public interface ISaveLoadSettingsService
    {
        SettingsData Load();
        void Save(SettingsData settingsData);
    }
}