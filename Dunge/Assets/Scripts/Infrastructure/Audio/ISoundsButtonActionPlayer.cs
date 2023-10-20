namespace Scripts.Infrastructure.Audio
{
    interface ISoundsButtonActionPlayer
    {
        void PlayButtonPressSound();
        void PlayPauseSound();
        void PlayUnpauseSound();
    }
}