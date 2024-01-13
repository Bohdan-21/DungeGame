using Scripts.Infrastructure.Audio;
using Scripts.Services.AudioService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Settings
{
    public class SettingsUI : MonoBehaviour, ISettingsUI
    {
        [SerializeField] private Slider musicVolume;
        [SerializeField] private Slider soundVolume;

        private IAudioService _audioService;
        private ISoundsButtonActionPlayer _soundsButtonActionPlayer;

        [Inject]
        private void Construct(IAudioService audioService, ISoundsButtonActionPlayer soundsButtonActionPlayer)
        {
            _audioService = audioService;
            _soundsButtonActionPlayer = soundsButtonActionPlayer;
        }

        private void Start()
        {
            Hide();

            UpdateSlider();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _soundsButtonActionPlayer.PlayButtonPressSound();

            gameObject.SetActive(false);
        }

        public void UpdateMusicVolume()
        {
            _audioService.UpdateMusicVolume(musicVolume.value);
        }

        public void UpdateSoundVolume()
        {
            _audioService.UpdateSoundVolume(soundVolume.value);
        }

        private void UpdateSlider()
        {
            musicVolume.value = _audioService.AudioSetting.MusicVolume;
            soundVolume.value = _audioService.AudioSetting.SoundVolume;
        }
    }
}