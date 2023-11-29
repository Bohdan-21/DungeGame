using Scripts.SaveData.Experience;
using Scripts.SaveData.SkillTree;
using Scripts.SaveData.Stats;
using System;
using UnityEngine;

namespace Scripts.StaticData.EnemyStaticData
{
    [CreateAssetMenu(fileName = "EnemyCharacterDeffaultSettings", menuName = "StaticData/Enemy/EnemyCharacterDeffaultSettings")]
    [Serializable]
    public class EnemyCharacterDeffaultSettings : ScriptableObject
    {
        public EnemyExperienceData EnemyExperienceData;
        public EnemySkillTreeData EnemySkillTreeData;
        public StatsContainer EnemyStatsContainer;
    }
}