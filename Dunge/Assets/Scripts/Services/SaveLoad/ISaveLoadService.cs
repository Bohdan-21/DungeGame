using Scripts.SaveData;

namespace Scripts.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        PlayerProgress LoadProgress();
        void SaveProgress();
    }
}