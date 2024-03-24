using Scripts.Services.AudioServices;
using Scripts.StaticData.SystemConfigData.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.Services.AudioService.SoundService
{
    class SoundsButtonActionPlayer : MonoBehaviour, ISoundsButtonActionPlayer
    {
        [SerializeField] private AudioSource _audio;
        private SoundListForButtonAction _soundList;
        private IAudioSettingService _audioService;

        [Inject]
        private void Construct(SoundListForButtonAction soundList, IAudioSettingService audioService)
        {
            _soundList = soundList;
            _audioService = audioService;
        }

        private void Awake()
        {
            _audioService.SoundVolumeUpdater += UpdateSoundVolume;

            UpdateSoundVolume();
        }

        private void OnDestroy()
        {
            _audioService.SoundVolumeUpdater -= UpdateSoundVolume;
        }

        public void PlayPauseSound()
        {
            _audio.PlayOneShot(_soundList.PauseSound);
        }

        public void PlayUnpauseSound()
        {
            _audio.PlayOneShot(_soundList.UnpauseSound);
        }

        public void PlayButtonPressSound()
        {
            _audio.PlayOneShot(_soundList.ButtonPressSound);
        }

        private void UpdateSoundVolume()
        {
            _audio.volume = _audioService.AudioSettingData.SoundVolume;
        }
    }
}
