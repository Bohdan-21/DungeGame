using Scripts.GameSystem.SkillTreeSystem.Type;
using System;
using UnityEngine;

namespace Scripts.GameSystem.SkillTreeSystem.Data
{
    [Serializable]
    public class AttributeData
    {
        public AttributeType AttributeType;
        public SkillType baseSkillType;

        [Header("Level Data")]
        public int AttributeLevel = 0;
        public int MaxAttributeLevel = 10;

        [Header("Boost")]
        public float Boost = 0.5f;


        public AttributeType GetAttributeType() => AttributeType;

        public SkillType GetBaseSkillType() => baseSkillType;

        public int GetAttributeLevel() => AttributeLevel;


        public float GetCurrentBoost() =>
            AttributeLevel * Boost;

        public bool CanUpgrateLevel() =>
            MaxAttributeLevel > AttributeLevel;

        public void UpLevel() =>
            AttributeLevel++;
    }
}
