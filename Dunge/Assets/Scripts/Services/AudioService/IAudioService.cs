using Scripts.StaticData.SystemConfigData.Audio;
using System;

namespace Scripts.Services.AudioService
{
    public interface IAudioService
    {
        AudioSetting AudioSetting { get; }

        event Action MusicVolumeUpdater;
        event Action SoundVolumeUpdater;

        void UpdateMusicVolume(float volume);
        void UpdateSoundVolume(float volume);
    }
}