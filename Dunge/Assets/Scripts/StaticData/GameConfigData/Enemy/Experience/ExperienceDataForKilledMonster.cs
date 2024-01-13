using Scripts.Enemy;
using System;

namespace Scripts.StaticData.GameConfigData.Enemy.Experience
{
    [Serializable]
    class ExperienceDataForKilledMonster
    {
        public EnemyType EnemyType;
        public int ExperienceForBaseLevel;
        public int ExperienceForEachNextLevel;
    }
}
