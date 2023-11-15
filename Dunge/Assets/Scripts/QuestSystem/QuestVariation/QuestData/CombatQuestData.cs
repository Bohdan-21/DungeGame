using Scripts.Enemy;
using System;

namespace Scripts.QuestSystem.QuestVariation.Data
{
    [Serializable]
    public class CombatQuestData : QuestData
    {
        public EnemyType EnemyType;
        public int AmountEnemyToKill;
        public int CurrentEnemyKill;
    }
}
