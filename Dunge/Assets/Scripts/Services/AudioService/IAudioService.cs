using Scripts.Services.SettingsService;
using Scripts.StaticData.SystemConfigData.Audio;
using System;

namespace Scripts.Services.AudioService
{
    public interface IAudioService
    {
        AudioSettingData AudioSettingData { get; }

        event Action MusicVolumeUpdater;
        event Action SoundVolumeUpdater;

        void UpdateMusicVolume(float volume);
        void UpdateSoundVolume(float volume);
    }
}