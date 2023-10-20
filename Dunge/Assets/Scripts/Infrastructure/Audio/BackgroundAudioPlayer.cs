using Scripts.Services.AudioService;
using Scripts.StaticData.Audio;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Audio
{
    public class BackgroundAudioPlayer : MonoBehaviour, IBackgroundAudioPlayer
    {
        [SerializeField] private AudioSource _audio;

        private PlayList _playList;
        private IAudioService _audioService;

        private bool _isNeedPlaying;
        private int _nextPlayingClip;

        [Inject]
        private void Construct(PlayList playList, IAudioService audioService)
        {
            _playList = playList;
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

        public void PlayBackgroundMusic()
        {
            UpdateMusicVolume();

            _isNeedPlaying = true;
        }

        private void Update()
        {
            if (_isNeedPlaying)
            {
                if (IsMusicStopPlaying())
                {
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
            _audio.volume = _audioService.AudioSetting.MusicVolume;
        }
    }
}