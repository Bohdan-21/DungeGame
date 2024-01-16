using Scripts.GameSystem.ExperienceSystem.Data;
using Scripts.GameSystem.SkillTreeSystem.Data;
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