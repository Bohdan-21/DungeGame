using Scripts.SaveData.PlayerData;

namespace Scripts.Services.SaveLoadServices.Player
{
    public interface IPlayerProgressSaveLoadService
    {
        PlayerProgress LoadProgress();
        void SaveProgress();
    }
}