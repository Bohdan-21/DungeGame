namespace Scripts.Services.AudioService.SoundService
{
    public interface ISoundsButtonActionPlayer
    {
        void PlayButtonPressSound();
        void PlayPauseSound();
        void PlayUnpauseSound();
    }
}