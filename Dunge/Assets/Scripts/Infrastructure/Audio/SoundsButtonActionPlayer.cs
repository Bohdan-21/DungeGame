using Scripts.Services.AudioService;
using Scripts.StaticData.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Audio
{
    class SoundsButtonActionPlayer : MonoBehaviour, ISoundsButtonActionPlayer
    {
        [SerializeField] private AudioSource _audio;
        private SoundListForButtonAction _soundList;
        private IAudioService _audioService;

        [Inject]
        private void Construct(SoundListForButtonAction soundList, IAudioService audioService)
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
            _audio.volume = _audioService.AudioSetting.SoundVolume;
        }
    }
}
