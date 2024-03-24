using Scripts.SaveData.PlayerData;

namespace Scripts.Services.PlayerProgressService
{
    public interface IPlayerProgressUpdater
    {
        void UpdateProgress(PlayerProgress playerProgress);
    }
}