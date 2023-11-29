using System;
using System.Collections.Generic;

namespace Scripts.SaveData.SkillTree
{
    //TODO:возможно нужно будет добавить очистку
    [Serializable]
    public class PlayerSkillTreeData
    {
        public List<SkillData> skills;
        public List<AttributeData> attributes;

        public int SkillPointForUpgrate = 0;
        public int AttributePointForUpgrate = 0;

        public PlayerSkillTreeData()
        {
            skills = new List<SkillData>();
            attributes = new List<AttributeData>();

            SkillPointForUpgrate = AttributePointForUpgrate = 0;
        }

        public PlayerSkillTreeData(PlayerSkillTreeData skillTreeData)
        {
            skills = new List<SkillData>();

            foreach (SkillData skillData in skillTreeData.skills)
                skills.Add(new SkillData(skillData));

            attributes = new List<AttributeData>();

            foreach (AttributeData attributeData in skillTreeData.attributes)
                attributes.Add(new AttributeData(attributeData));

            SkillPointForUpgrate = skillTreeData.SkillPointForUpgrate;
            AttributePointForUpgrate = skillTreeData.AttributePointForUpgrate;
        }
    }
}