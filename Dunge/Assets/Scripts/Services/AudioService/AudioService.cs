using Scripts.SaveData.SettingsData;
using Scripts.SaveData.SettingsData.Audio;
using Scripts.Services.SettingsService;
using System;

namespace Scripts.Services.AudioService
{
    public class AudioService : IAudioService, ISettingService
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
            AudioSettingData = new AudioSettingData(settingsData.AudioSettingData);
        }

        public void UpdateSettings(SettingsData settingsData)
        {
            settingsData.AudioSettingData = new AudioSettingData(AudioSettingData);
        }
    }
}
