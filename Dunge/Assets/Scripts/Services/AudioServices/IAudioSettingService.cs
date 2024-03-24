using Scripts.SaveData.SettingsData.Audio;
using Scripts.StaticData.SystemConfigData.Audio;
using System;

namespace Scripts.Services.AudioServices
{
    public interface IAudioSettingService
    {
        AudioSettingData AudioSettingData { get; }

        event Action MusicVolumeUpdater;
        event Action SoundVolumeUpdater;

        void UpdateMusicVolume(float volume);
        void UpdateSoundVolume(float volume);
    }
}