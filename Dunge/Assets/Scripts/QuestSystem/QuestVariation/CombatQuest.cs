using Scripts.Data.SaveData;
using Scripts.Enemy;
using Scripts.Extension;
using Scripts.Player;
using Scripts.QuestSystem.Channel;
using Scripts.QuestSystem.QuestVariation.BaseQuest;
using Scripts.QuestSystem.QuestVariation.Data;
using Scripts.Services.PlayerProgressService;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem.QuestVariation
{
    public class CombatQuest : Quest
    {
        [SerializeField] private CombatQuestData _combatQuestData;
        
        private CombatChannel _combatChannel;

        public override string Progress { get => "Progress: " + _combatQuestData.CurrentEnemyKill.ToString() + "/" 
                + _combatQuestData.AmountEnemyToKill.ToString(); }

        public override QuestData QuestData { get => _combatQuestData; }

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
            if (enemyType != _combatQuestData.EnemyType)
                return;
            if (_combatQuestData.CurrentEnemyKill < _combatQuestData.AmountEnemyToKill)
                RefreshQuestProgress();
            if (_combatQuestData.CurrentEnemyKill >= _combatQuestData.AmountEnemyToKill)
                QuestComplete();
        }

        protected override void RefreshQuestProgress()
        {
            _combatQuestData.CurrentEnemyKill++;
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
            return "Kill enemy:" + _combatQuestData.CurrentEnemyKill.ToString() + "/" + _combatQuestData.AmountEnemyToKill.ToString();
        }

        public override void InitializeQuestData(QuestData questData)
        {
            if (questData is CombatQuestData combatData)
                _combatQuestData = combatData;
        }
    }
}
