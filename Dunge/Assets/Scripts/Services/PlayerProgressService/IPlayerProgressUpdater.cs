using Scripts.SaveData;

namespace Scripts.Services.PlayerProgressService
{
    public interface IPlayerProgressUpdater
    {
        void UpdateProgress(PlayerProgress playerProgress);
    }
}