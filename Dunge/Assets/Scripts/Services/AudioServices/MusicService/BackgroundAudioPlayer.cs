using Scripts.Services.AudioService.MusicService;
using Scripts.StaticData.SystemConfigData.Audio;
using UnityEngine;
using Zenject;

namespace Scripts.Services.AudioServices.MusicService
{
    public class BackgroundAudioPlayer : MonoBehaviour, IBackgroundAudioPlayer
    {
        [SerializeField] private AudioSource _audio;

        private PlayList _playList = null;
        private IAudioSettingService _audioService;

        private bool _isNeedPlaying;
        private int _nextPlayingClip;

        [Inject]
        private void Construct(IAudioSettingService audioService)
        {
            _audioService = audioService;
        }

        private void Awake()
        {
            _isNeedPlaying = false;
            _nextPlayingClip = 0;

            _audioService.MusicVolumeUpdater += UpdateMusicVolume;
        }

        private void OnDestroy()
        {
            _audioService.MusicVolumeUpdater -= UpdateMusicVolume;
        }

        public void StartPlayBackgroundMusic()
        {
            UpdateMusicVolume();

            _isNeedPlaying = true;
        }

        public void StopPlayBackGroundMusic()
        {
            _audio.Stop();

            _playList = null;

            _isNeedPlaying = false;
        }

        public void SetPlayList(PlayList playList)
        {
            _playList = playList;

            _nextPlayingClip = 0;
        }

        private void Update()
        {
            if (_isNeedPlaying)
            {
                if (IsMusicStopPlaying())
                {
                    if (_playList == null)
                        return;
                    StartPlayNextClip();

                    UpdateCounterForNextPlayingClip();
                }
            }
        }

        private bool IsMusicStopPlaying()
        {
            return !_audio.isPlaying;
        }

        private void StartPlayNextClip()
        {
            _audio.PlayOneShot(_playList.AudioClips[_nextPlayingClip]);
        }

        private void UpdateCounterForNextPlayingClip()
        {
            _nextPlayingClip++;

            if (_nextPlayingClip >= _playList.AudioClips.Count)
                _nextPlayingClip = 0;
        }

        private void UpdateMusicVolume()
        {
            _audio.volume = _audioService.AudioSettingData.MusicVolume;
        }
    }
}