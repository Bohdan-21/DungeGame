using Scripts.StaticData.SystemConfigData.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Services.AudioService
{
    class AudioService : IAudioService
    {
        public AudioSetting AudioSetting { get; private set; }

        public event Action MusicVolumeUpdater;
        public event Action SoundVolumeUpdater;

        public AudioService(AudioSetting audioSettings)
        {
            AudioSetting = audioSettings;
        }

        public void UpdateMusicVolume(float volume)
        {
            AudioSetting.MusicVolume = volume;

            MusicVolumeUpdater?.Invoke();
        }

        public void UpdateSoundVolume(float volume)
        {
            AudioSetting.SoundVolume = volume;

            SoundVolumeUpdater?.Invoke();
        }
    }
}
