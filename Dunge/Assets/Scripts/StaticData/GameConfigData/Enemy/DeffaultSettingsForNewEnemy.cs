using Scripts.SaveData.Experience;
using Scripts.SaveData.SkillTree;
using Scripts.SaveData.Stats;
using System;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.Enemy
{
    [CreateAssetMenu(fileName = "DeffaultSettingsForNewEnemy", menuName = "StaticData/GameConfigData/Enemy/DeffaultSettingsForNewEnemy")]
    [Serializable]
    public class DeffaultSettingsForNewEnemy : ScriptableObject
    {
        public EnemyExperienceData EnemyExperienceData;
        public EnemySkillTreeData EnemySkillTreeData;
        public StatsContainer EnemyStatsContainer;
    }
}