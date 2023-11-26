using Scripts.GameSystem.StatsSystem.Type;
using System;
using UnityEngine;

namespace Scripts.GameSystem.StatsSystem.Data
{
    [Serializable]
    public class StatData
    {
        public TypeStat typeStat;

        [Header("Value")]
        public float baseValue;
        public float currentValue;

        public void RecalculateCurrentValue(float boost) =>
            currentValue = baseValue + boost;
    }
}
