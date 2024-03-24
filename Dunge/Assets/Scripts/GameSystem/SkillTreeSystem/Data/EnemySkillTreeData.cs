using Scripts.SaveData.PlayerData.SkillTree;
using System;
using System.Collections.Generic;

namespace Scripts.GameSystem.SkillTreeSystem.Data
{
    [Serializable]
    public class EnemySkillTreeData
    {
        public List<AttributeData> attributes;

        public EnemySkillTreeData() =>
            attributes = new List<AttributeData>();

        public EnemySkillTreeData(EnemySkillTreeData enemySkillTreeData)
        {
            attributes = new List<AttributeData>();

            foreach (AttributeData attributeData in enemySkillTreeData.attributes)
                attributes.Add(new AttributeData(attributeData));
        }
    }
}