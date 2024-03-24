using System;
using UnityEngine;

namespace Scripts.SaveData.SettingsData.Audio
{
    [Serializable]
    public class AudioSettingData
    {
        [Range(0f, 1f)]
        public float MusicVolume = 0.5f;

        [Range(0f, 1f)]
        public float SoundVolume = 0.5f;

        public AudioSettingData()
        {
            MusicVolume = SoundVolume = 0.5f;
        }

        public AudioSettingData(AudioSettingData audioSettingData)
        {
            MusicVolume = audioSettingData.MusicVolume;
            SoundVolume = audioSettingData.SoundVolume;
        }
    }
}
