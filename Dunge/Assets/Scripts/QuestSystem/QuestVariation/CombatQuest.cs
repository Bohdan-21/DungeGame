using Scripts.Enemy;
using Scripts.Player;
using System;
using Zenject;

namespace Scripts.QuestSystem.QuestVariation
{
    public class CombatQuest : Quest
    {
        public EnemyType EnemyToKill;
        public int amountEnemyToKill;
        public int currentEnemyKill;
        
        //public CombatChannel _combatChannel;
        private QuestChannel _questChannel;
        
        [Inject]
        private void Construct(QuestChannel questChannel)
        {
            //_combatChannel = CombatChannel.Instance;
            _questChannel = questChannel;
        }

        private void Start()
        {
            StartTrackingQuest();
        }


        private void StartTrackingQuest()
        {
            _questChannel.ActivateQuest(this);

            //_combatChannel.KillEvent += TrackingKillEvent;
        }

        private void TrackingKillEvent(EnemyType enemyType)
        {
            if (enemyType != EnemyToKill)
                return;
            if (currentEnemyKill < amountEnemyToKill)
            {
                currentEnemyKill++;
                _questChannel.RefreshQuest(this);
            }
            if(currentEnemyKill >= amountEnemyToKill)
            {
                _questChannel.CompleteQuest(this);
                //_combatChannel.KillEvent -= TrackingKillEvent;

                Destroy(this.gameObject);
            }
        }

        public override string ToString()
        {
            return "Kill enemy:" + currentEnemyKill.ToString() + "/" + amountEnemyToKill.ToString();
        }
    }
}
