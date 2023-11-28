using Scripts.GameSystem.SkillTreeSystem.Data;
using System;
using System.Collections.Generic;

namespace Scripts.GameSystem.SkillTreeSystem.Logic
{
    //TODO:возможно нужно будет добавить очистку
    [Serializable]
    public class SkillTreeData
    {
        public List<SkillData> skills;
        public List<AttributeData> attributes;

        public int SkillPointForUpgrate = 0;
        public int AttributePointForUpgrate = 0;

        public SkillTreeData()
        {
            skills = new List<SkillData>();
            attributes = new List<AttributeData>();

            SkillPointForUpgrate = AttributePointForUpgrate = 0;
        }

        public SkillTreeData(SkillTreeData skillTreeData)
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