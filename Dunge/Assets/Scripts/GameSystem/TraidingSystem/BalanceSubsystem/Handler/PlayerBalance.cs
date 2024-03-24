using Scripts.SaveData.PlayerData;
using Scripts.SaveData.PlayerData.Money;
using Scripts.Services.PlayerProgressService;
using System;
using Zenject;

namespace Scripts.GameSystem.TraidingSystem.BalanceSubsystem.Handler
{
    public class PlayerBalance : Balance, IPlayerProgressLoader
    {
        public event Action UpdatePlayerMoneyEvent;

        [Inject]
        private void Construct(IPlayerProgressService progressService) =>
            progressService.AddProgressUpdater(this);

        public override void Reimburse(int money)
        {
            base.Reimburse(money);
            UpdatePlayerMoneyEvent?.Invoke();
        }

        public override void Pay(int money)
        {
            base.Pay(money);
            UpdatePlayerMoneyEvent?.Invoke();
        }

        public void LoadProgress(PlayerProgress playerProgress) =>
            _moneyData = new MoneyData(playerProgress.PlayerMoney);

        public void UpdateProgress(PlayerProgress playerProgress) =>
            playerProgress.PlayerMoney = new MoneyData(_moneyData);
    }
}
