using Scripts.GameSystem.ExperienceSystem.Handler;
using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.SaveData.PlayerData;
using Scripts.SaveData.PlayerData.SkillTree;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.GameConfigData.GameSystem.SkillTree.EnumLinks;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.SkillTreeSystem.Handler
{
    public class PlayerSkillTreeHandler : MonoBehaviour, IPlayerProgressLoader
    {
        [SerializeField] private PlayerExperienceHandler _playerExperience;
        [SerializeField] private PlayerSkillTreeData _skillTreeData;
        
        private ListEnumLinksFromAttributeToSkill _enumLinks;

        public event Action UpgrateAttributeLevelEvent;

        [Inject]
        private void Construct(IPlayerProgressService playerProgressService, ListEnumLinksFromAttributeToSkill enumLinks)
        {
            playerProgressService.AddProgressUpdater(this);
            _enumLinks = enumLinks;
        }

        private void Start()
        {
            _playerExperience.LevelUpEvent += PlayerLevelUp;
        }

        private void OnDestroy()
        {
            _playerExperience.LevelUpEvent -= PlayerLevelUp;
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
            SkillData skillData = GetSkillDataByType(_enumLinks.GetSkillType(attributeData.GetAttributeType()));

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

        public void LoadProgress(PlayerProgress playerProgress) =>
            _skillTreeData = new PlayerSkillTreeData(playerProgress.SkillTreeData);

        public void UpdateProgress(PlayerProgress playerProgress) =>
            playerProgress.SkillTreeData = new PlayerSkillTreeData(_skillTreeData);
    }
}