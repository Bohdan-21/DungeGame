using Scripts.Services.SettingsService;
using Scripts.StaticData.SystemConfigData.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Services.AudioService
{
    class AudioService : IAudioService, ISettingService
    {
        private ISettingsServiceHandler _settingsServiceHandler;

        public AudioSettingData AudioSettingData { get; private set; } = new AudioSettingData();

        public event Action MusicVolumeUpdater;
        public event Action SoundVolumeUpdater;

        public AudioService(ISettingsServiceHandler settingsServiceHandler)
        {
            _settingsServiceHandler = settingsServiceHandler;

            _settingsServiceHandler.AddService(this);
        }

        ~AudioService()
        {
            _settingsServiceHandler.RemoveService(this);
        }

        public void UpdateMusicVolume(float volume)
        {
            AudioSettingData.MusicVolume = volume;

            MusicVolumeUpdater?.Invoke();
        }

        public void UpdateSoundVolume(float volume)
        {
            AudioSettingData.SoundVolume = volume;

            SoundVolumeUpdater?.Invoke();
        }

        public void LoadSettings(SettingsData settingsData)
        {
            AudioSettingData.MusicVolume = settingsData.AudioSettingData.MusicVolume;
            AudioSettingData.SoundVolume = settingsData.AudioSettingData.SoundVolume;
        }

        public void UpdateSettings(SettingsData settingsData)
        {
            settingsData.AudioSettingData.MusicVolume = AudioSettingData.MusicVolume;
            settingsData.AudioSettingData.SoundVolume = AudioSettingData.SoundVolume;
        }
    }
}
