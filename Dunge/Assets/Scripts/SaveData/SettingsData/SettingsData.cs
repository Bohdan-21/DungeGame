using Scripts.LanguageLocalization;
using Scripts.SaveData.SettingsData.Audio;
using Scripts.SaveData.SettingsData.ControlButton;
using Scripts.StaticData.SystemConfigData.Audio;
using System;

namespace Scripts.SaveData.SettingsData
{
    [Serializable]
    public class SettingsData
    {
        public AudioSettingData AudioSettingData;
        public ControlButtonsData ControlButtonsData;

        public Language GameLanguage;
    }
}
