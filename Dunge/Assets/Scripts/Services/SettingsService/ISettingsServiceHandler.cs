using Scripts.SaveData.SettingsData;

namespace Scripts.Services.SettingsService
{
    public interface ISettingsServiceHandler
    {
        SettingsData SettingsData { get; set; }

        void AddService(ISettingService service);
        void AllertAllLoadSettings();
        void AllertAllUpdateSettings();
        void RemoveService(ISettingService service);
    }
}