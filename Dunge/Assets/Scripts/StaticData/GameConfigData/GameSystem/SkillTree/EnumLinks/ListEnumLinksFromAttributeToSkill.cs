using Scripts.GameSystem.SkillTreeSystem.Type;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.GameSystem.SkillTree.EnumLinks
{
    [CreateAssetMenu(fileName = "EnumLinksFromAttributeToSkill", menuName = "StaticData/GameConfigData/GameSystem/SkillTree/EnumLinks/FromAttributeToSkill")]
    public class ListEnumLinksFromAttributeToSkill : ScriptableObject
    {
        [SerializeField] private List<EnumLinkFromAttributeToSkill> _enumLinks;

        public SkillType GetSkillType(AttributeType attributeType)
        {
            foreach (EnumLinkFromAttributeToSkill enumLink in _enumLinks)
            {
                if (enumLink.attributeType == attributeType)
                    return enumLink.skillType;
            }
            return SkillType.NONE;
        }
    }
}
