namespace Scripts.Services.AudioService.SoundService
{
    public interface ISoundsGameActionPlayer
    {
        void PlayHitPlayerSound();
        void PlayAttackPlayerSound();
        void PlayUseItemSound();
        void PlayTeleportSound();
        void PlayAttackEnemySound();
        void PlayHitEnemySound();
        void PlayPlayerLoseSound();
        void PLayEnemyDieSound();
        void PlayPickUpItemSound();
    }
}