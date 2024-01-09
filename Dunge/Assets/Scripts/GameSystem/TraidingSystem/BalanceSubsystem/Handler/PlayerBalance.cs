using Scripts.SaveData;
using Scripts.SaveData.Money;
using Scripts.Services.PlayerProgressService;
using Zenject;

namespace Scripts.GameSystem.TraidingSystem.BalanceSubsystem.Handler
{
    public class PlayerBalance : Balance, IPlayerProgressLoader
    {
        [Inject]
        private void Construct(IPlayerProgressService progressService) =>
            progressService.AddProgressUpdater(this);

        public void LoadProgress(PlayerProgress playerProgress) =>
            _moneyData = new MoneyData(playerProgress.PlayerMoney);

        public void UpdateProgress(PlayerProgress playerProgress) =>
            playerProgress.PlayerMoney = new MoneyData(_moneyData);
    }
}
