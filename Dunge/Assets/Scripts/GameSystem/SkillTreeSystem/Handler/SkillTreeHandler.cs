using Scripts.GameSystem.ExperienceSystem.Player;
using Scripts.GameSystem.SkillTreeSystem.Data;
using Scripts.GameSystem.SkillTreeSystem.Type;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameSystem.SkillTreeSystem.Logic
{
    public class SkillTreeHandler : MonoBehaviour
    {
        [SerializeField] private SkillTreeData _skillTreeData;

        public static SkillTreeHandler Instance;

        public event Action UpgrateAttributeLevelEvent;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            PlayerExperience.Instance.PlayerLevelUpEvent += PlayerLevelUp;
        }


        public int GetCountSkillPoint() => _skillTreeData.SkillPointForUpgrate;

        public int GetCountAttributePoint() => _skillTreeData.AttributePointForUpgrate;

        public IEnumerable<SkillData> GetSkillData()
        {
            foreach (SkillData skillData in _skillTreeData.skills)
                yield return skillData;
        }

        public IEnumerable<AttributeData> GetAttributeData()
        {
            foreach (AttributeData attributeData in _skillTreeData.attributes)
                yield return attributeData;
        }


        private void PlayerLevelUp()
        {
            _skillTreeData.SkillPointForUpgrate++;
            _skillTreeData.AttributePointForUpgrate++;
        }


        public bool CanUpgrateSkill(SkillType skillType)
        {
            SkillData skillData = GetSkillDataByType(skillType);

            if (skillData != null)
                if (skillData.CanUpgrateSkill() && _skillTreeData.SkillPointForUpgrate > 0)
                    return true;
            return false;
        }

        public bool CanUpgrateAttribute(AttributeType attributeType)
        {
            AttributeData attributeData = GetAttributeDataByType(attributeType);

            if (attributeData != null)
                return CanUpgrateAttribute(attributeData);

            return false;
        }

        private bool CanUpgrateAttribute(AttributeData attributeData)
        {
            SkillData skillData = GetSkillDataByType(attributeData.GetBaseSkillType());

            if (skillData != null)
                if (skillData.CanUpgrateAttribute(attributeData) && _skillTreeData.AttributePointForUpgrate > 0)
                    return true;
            return false;
        }


        public SkillData GetSkillDataByType(SkillType skillType)
        {
            foreach (SkillData skill in _skillTreeData.skills)
                if (skill.GetSkillType() == skillType)
                    return skill;
            return null;
        }

        public AttributeData GetAttributeDataByType(AttributeType attributeType)
        {
            foreach (AttributeData attribute in _skillTreeData.attributes)
                if (attribute.GetAttributeType() == attributeType)
                    return attribute;
            return null;
        }


        public void UpgrateSkill(SkillType skillType)
        {
            if (CanUpgrateSkill(skillType))
            {
                SkillData skillData = GetSkillDataByType(skillType);

                _skillTreeData.SkillPointForUpgrate--;

                skillData.UpLevel();
            }
        }

        public void UpgrateAttribute(AttributeType attributeType)
        {
            if (CanUpgrateAttribute(attributeType))
            {
                AttributeData attributeData = GetAttributeDataByType(attributeType);

                _skillTreeData.AttributePointForUpgrate--;

                attributeData.UpLevel();

                UpgrateAttributeLevelEvent?.Invoke();
            }
        }
    }
}