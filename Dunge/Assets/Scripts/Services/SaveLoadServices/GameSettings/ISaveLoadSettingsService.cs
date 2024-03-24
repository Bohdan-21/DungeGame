using Scripts.SaveData.SettingsData;

namespace Scripts.Services.SaveLoadServices.GameSettings
{
    public interface ISaveLoadSettingsService
    {
        SettingsData Load();
        void Save(SettingsData settingsData);
    }
}