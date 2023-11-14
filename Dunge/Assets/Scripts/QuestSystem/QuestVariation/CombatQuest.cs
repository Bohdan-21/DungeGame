using Scripts.Enemy;
using Scripts.Player;
using Scripts.QuestSystem.Channel;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem.QuestVariation
{
    public class CombatQuest : Quest
    {
        [SerializeField] private EnemyType EnemyToKill;
        [SerializeField] private int amountEnemyToKill;
        [SerializeField] private int currentEnemyKill;
        
        private CombatChannel _combatChannel;

        public override string Progress { get => "Progress: " + currentEnemyKill.ToString() + "/" + amountEnemyToKill.ToString(); }

        [Inject]
        private void Construct(QuestChannel questChannel, CombatChannel combatChannel)
        {
            _questChannel = questChannel;
            _combatChannel = combatChannel;
        }

        private void Start()
        {
            AlertForCreatedQuest();
        }

        public override void StartTrackingQuest() => 
            _combatChannel.KillEvent += TrackingKillEvent;

        public override void StopTrackingQuest() => 
            _combatChannel.KillEvent -= TrackingKillEvent;

        private void TrackingKillEvent(EnemyType enemyType)
        {
            if (enemyType != EnemyToKill)
                return;
            if (currentEnemyKill < amountEnemyToKill)
                RefreshQuestProgress();
            if (currentEnemyKill >= amountEnemyToKill)
                QuestComplete();
        }

        protected override void RefreshQuestProgress()
        {
            currentEnemyKill++;
            _questChannel.RefreshActiveQuest();
        }

        protected override void QuestComplete()
        {
            _questChannel.CompleteQuest(this);

            StopTrackingQuest();

            Destroy(this.gameObject);
        }

        public override string ToString()
        {
            return "Kill enemy:" + currentEnemyKill.ToString() + "/" + amountEnemyToKill.ToString();
        }
    }
}
