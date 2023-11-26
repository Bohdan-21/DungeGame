using Scripts.GameSystem.SkillTreeSystem.Data;
using System;
using System.Collections.Generic;

namespace Scripts.GameSystem.SkillTreeSystem.Logic
{
    [Serializable]
    public class SkillTreeData
    {
        public List<SkillData> skills;
        public List<AttributeData> attributes;

        public int SkillPointForUpgrate = 0;
        public int AttributePointForUpgrate = 0;
    }
}