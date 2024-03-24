using Scripts.StaticData.SystemConfigData.Audio;

namespace Scripts.Services.AudioService.MusicService
{
    public interface IBackgroundAudioPlayer
    {
        void StartPlayBackgroundMusic();
        void SetPlayList(PlayList playList);
        void StopPlayBackGroundMusic();
    }
}