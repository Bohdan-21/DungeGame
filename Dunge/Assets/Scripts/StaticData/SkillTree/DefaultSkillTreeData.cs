using Scripts.GameSystem.SkillTreeSystem.Logic;
using UnityEngine;

namespace Scripts.SkillTree.Logic
{
    [CreateAssetMenu(fileName = "DefaultSkillTreeData", menuName = "StaticData/SkillTreeData/DefaultSkillTreeData")]
    public class DefaultSkillTreeData : ScriptableObject
    {
        public SkillTreeData skillTreeData;
    }
}