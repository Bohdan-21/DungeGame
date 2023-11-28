using Scripts.GameSystem.StatsSystem.Type;
using System;
using UnityEngine;

namespace Scripts.SaveData.Stats
{
    [Serializable]
    public class StatData
    {
        public TypeStat typeStat;

        [Header("Value")]
        public float baseValue;
        public float currentValue;

        public StatData()
        {
            typeStat = TypeStat.HealthPoint;
            baseValue = currentValue = 0;
        }

        public StatData(StatData statData)
        {
            typeStat = statData.typeStat;
            baseValue = statData.baseValue;
            currentValue = statData.currentValue;
        }

        public void RecalculateCurrentValue(float boost) =>
            currentValue = baseValue + boost;
    }
}
