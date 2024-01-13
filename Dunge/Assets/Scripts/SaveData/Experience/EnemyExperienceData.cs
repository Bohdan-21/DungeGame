using Scripts.StaticData.GameConfigData.Enemy;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.SaveData.Experience
{
    [Serializable]
    public class EnemyExperienceData
    {
        [SerializeField] private int _currentLevel;
        [SerializeField] private int _highestLimitForLevel;

        public EnemyExperienceData(DeffaultSettingsForNewEnemy deffaultSettings, int currentDungeLevel)
        {
            _highestLimitForLevel = deffaultSettings.EnemyExperienceData._highestLimitForLevel;

            _currentLevel = SetRandomLevel(currentDungeLevel);
        }

        public int GetCurrentLevel() =>
            _currentLevel;

        private int SetRandomLevel(int currentDungeLevel)
        {
            int minLevel = _highestLimitForLevel * currentDungeLevel;
            int maxLevel = _highestLimitForLevel + minLevel;

            return UnityEngine.Random.Range(minLevel, maxLevel);
        }
    }
}
