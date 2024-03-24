using Scripts.SaveData.PlayerData;
using Scripts.Services.PlayerProgressService;

namespace Scripts.Services.SaveLoadServices.Player
{
    public class PlayerProgressSaveLoadService : IPlayerProgressSaveLoadService
    {
        private readonly IPlayerProgressService _playerProgressService;

        public PlayerProgressSaveLoadService(IPlayerProgressService playerProgressService)
        {
            _playerProgressService = playerProgressService;
        }

        public void SaveProgress()
        {
            CleanAllPlayerProgress();

            foreach (IPlayerProgressUpdater progressUpdater in _playerProgressService.ProgressUpdaters)
                progressUpdater.UpdateProgress(_playerProgressService.PlayerProgress);

            BinarySerializer.Serialize(_playerProgressService.PlayerProgress, "data.dat");
        }

        public PlayerProgress LoadProgress()
        {
            return BinarySerializer.Deserialize<PlayerProgress>("data.dat");
        }

        private void CleanAllPlayerProgress()
        {
            _playerProgressService.PlayerProgress.ClearAllData();
        }
    }
}
