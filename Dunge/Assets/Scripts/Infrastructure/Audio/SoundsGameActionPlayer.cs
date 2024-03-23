using Scripts.Services.AudioService;
using Scripts.StaticData.SystemConfigData.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Audio
{
    class SoundsGameActionPlayer : MonoBehaviour, ISoundsGameActionPlayer
    {
        [SerializeField] private AudioSource _audio;
        private SoundListForGameAction _soundList;
        private IAudioService _audioService;

        [Inject]
        private void Construct(SoundListForGameAction soundList, IAudioService audioService)
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

        public void PlayUseItemSound() => 
            _audio.PlayOneShot(_soundList.UseItemSound);

        public void PlayAttackPlayerSound() => 
            _audio.PlayOneShot(_soundList.AttackPlayerSound);

        public void PlayAttackEnemySound() =>
            _audio.PlayOneShot(_soundList.AttackEnemySound);

        public void PlayHitPlayerSound() => 
            _audio.PlayOneShot(_soundList.HitPlayerSound);

        public void PlayHitEnemySound() =>
            _audio.PlayOneShot(_soundList.HitEnemySound);

        public void PlayTeleportSound() => 
            _audio.PlayOneShot(_soundList.TeleportSound);

        public void PlayPlayerLoseSound() =>
            _audio.PlayOneShot(_soundList.PlayerLose);

        public void PLayEnemyDieSound() =>
            _audio.PlayOneShot(_soundList.EnemyDeath);

        public void PlayPickUpItemSound() =>
            _audio.PlayOneShot(_soundList.PickUpItemSound);

        private void UpdateSoundVolume()
        {
            _audio.volume = _audioService.AudioSettingData.SoundVolume;
        }
    }
}
