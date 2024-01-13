using Scripts.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.Enemy.Experience
{
    [CreateAssetMenu(fileName = "ExperienceForKilledEnemy", menuName = "StaticData/GameConfigData/Enemy/ExperienceForKilledMonster")]
    public class ExperienceForKilledEnemy : ScriptableObject
    {
        [SerializeField] private List<ExperienceDataForKilledMonster> _experienceDataForKilledMonsters;

        public int GetExperience(EnemyType enemyType, int levelKilledMonster)
        {
            int experience = 0;

            foreach (ExperienceDataForKilledMonster experienceData in _experienceDataForKilledMonsters)
            {
                if (experienceData.EnemyType == enemyType)
                {
                    experience += experienceData.ExperienceForBaseLevel;
                    experience += levelKilledMonster * experienceData.ExperienceForEachNextLevel;
                    break;
                }
            }

            return experience;
        }
    }
}
