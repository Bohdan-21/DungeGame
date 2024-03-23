using Scripts.Extension;
using System;
using UnityEngine;

namespace Scripts.Services.SettingsService
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
