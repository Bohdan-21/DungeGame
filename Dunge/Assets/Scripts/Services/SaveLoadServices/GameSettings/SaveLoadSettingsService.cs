using Scripts.Extension;
using Scripts.SaveData.SettingsData;
using UnityEngine;

namespace Scripts.Services.SaveLoadServices.GameSettings
{
    public class SaveLoadSettingsService : ISaveLoadSettingsService
    {
        private const string Key = "GameSettings";

        public void Save(SettingsData settingsData)
        {
            PlayerPrefs.SetString(Key, settingsData.ToJson());
        }

        public SettingsData Load()
        {
            return PlayerPrefs.GetString(Key).FromJson<SettingsData>();
        }
    }
}
