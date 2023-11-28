using Scripts.GameSystem.SkillTreeSystem.Type;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.SaveData.SkillTree
{
    [Serializable]
    public class SkillData
    {
        public SkillType SkillType;

        [Header("Level Data")]
        public int SkillLevel = 0;
        public int MaxSkillLevel = 20;
        public int LevelMultiplierTreshold = 2;

        [Header("Boost Data")]
        public float Boost = 0;

        public SkillData()
        {
            SkillType = SkillType.Strength;
            SkillLevel = MaxSkillLevel = LevelMultiplierTreshold = 0;
            Boost = 0;
        }

        public SkillData(SkillData skillData)
        {
            SkillType = skillData.SkillType;
            SkillLevel = skillData.SkillLevel;
            MaxSkillLevel = skillData.MaxSkillLevel;
            LevelMultiplierTreshold = skillData.LevelMultiplierTreshold;
            Boost = skillData.Boost;
        }

        public SkillType GetSkillType() => SkillType;

        public int GetSkillLevel() => SkillLevel;


        public bool CanUpgrateSkill() =>
            MaxSkillLevel > SkillLevel;

        public bool CanUpgrateAttribute(AttributeData attributeData) =>
            SkillLevel > attributeData.GetAttributeLevel() * LevelMultiplierTreshold && attributeData.CanUpgrateLevel();

        public float GetCurrentBoost() =>
            SkillLevel * Boost;

        public void UpLevel() =>
            SkillLevel++;
    }
}