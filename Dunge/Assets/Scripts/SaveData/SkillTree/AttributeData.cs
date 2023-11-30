using Scripts.GameSystem.SkillTreeSystem.Type;
using System;
using UnityEngine;

namespace Scripts.SaveData.SkillTree
{
    [Serializable]
    public class AttributeData
    {
        public AttributeType AttributeType;

        [Header("Level Data")]
        public int AttributeLevel = 0;
        public int MaxAttributeLevel = 10;

        [Header("Boost")]
        public float Boost = 0.5f;

        public AttributeData()
        {
            AttributeType = AttributeType.NONE;
            AttributeLevel = MaxAttributeLevel = 0;
            Boost = 0;
        }

        public AttributeData(AttributeData attributeData)
        {
            AttributeType = attributeData.AttributeType;
            AttributeLevel = attributeData.AttributeLevel;
            MaxAttributeLevel = attributeData.MaxAttributeLevel;
            Boost = attributeData.Boost;
        }

        public AttributeType GetAttributeType() => AttributeType;

        public int GetAttributeLevel() => AttributeLevel;


        public float GetCurrentBoost() =>
            AttributeLevel * Boost;

        public bool CanUpgrateLevel() =>
            MaxAttributeLevel > AttributeLevel;

        public void UpLevel() =>
            AttributeLevel++;
    }
}
