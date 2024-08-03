using Scripts.Enemy;
using Scripts.GameSystem.QuestSystem.Channel;
using Scripts.SaveData.PlayerData;
using Scripts.SaveData.PlayerData.Money;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.GameConfigData.Enemy.Experience;
using System;
using Zenject;

namespace Scripts.GameSystem.TraidingSystem.BalanceSubsystem.Handler
{
    public class PlayerBalance : Balance, IPlayerProgressLoader
    {
        private ExperienceForKilledEnemy _experienceForKilledMonster;
        private CombatChannel _combatChannel;

        public event Action UpdatePlayerMoneyEvent;

        [Inject]
        private void Construct(IPlayerProgressService progressService, ExperienceForKilledEnemy experienceForKilledEnemy,
                               CombatChannel combatChannel)
        {
            _experienceForKilledMonster = experienceForKilledEnemy;
            _combatChannel = combatChannel;
            progressService.AddProgressUpdater(this);
        }

        private void Start()
        {
            _combatChannel.KillEvent += KillEvent;
        }

        private void OnDestroy()
        {
            _combatChannel.KillEvent -= KillEvent;            
        }

        private void KillEvent(EnemyType enemyType, int levelKilledMonster)
        {
            int money = _experienceForKilledMonster.GetExperience(enemyType, levelKilledMonster) / 20;
            Reimburse(money);
        }

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
