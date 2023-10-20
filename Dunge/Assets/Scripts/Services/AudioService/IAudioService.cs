using Scripts.StaticData.Audio;
using System;

namespace Scripts.Services.AudioService
{
    interface IAudioService
    {
        AudioSetting AudioSetting { get; }

        event Action MusicVolumeUpdater;
        event Action SoundVolumeUpdater;

        void UpdateMusicVolume(float volume);
        void UpdateSoundVolume(float volume);
    }
}