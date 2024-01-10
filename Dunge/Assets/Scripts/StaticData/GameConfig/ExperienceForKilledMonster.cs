using Scripts.Enemy;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameStaticData
{
    [CreateAssetMenu(fileName = "ExperienceForKilledMonster", menuName = "StaticData/GameConfig/ExperienceForKilledMonster")]
    public class ExperienceForKilledMonster : ScriptableObject
    {
        [Serializable]
        class ExperienceDataForKilledMonster
        {
            public EnemyType EnemyType;
            public int ExperienceForBaseLevel;
            public int ExperienceForEachNextLevel;
        }

        [SerializeField] private List<ExperienceDataForKilledMonster> _experienceDataForKilledMonsters;

        public int GetExperience(EnemyType enemyType, int levelKilledMonster)
        {
            int experience = 0;

            foreach(ExperienceDataForKilledMonster experienceData in _experienceDataForKilledMonsters)
            {
                if(experienceData.EnemyType == enemyType)
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
