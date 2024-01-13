using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.GameSystem.StatsSystem.Type;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.GameSystem.SkillTree.EnumLinks
{
    [CreateAssetMenu(fileName = "EnumLinksFromStatToAttribute", menuName = "StaticData/GameConfigData/GameSystem/SkillTree/EnumLinks/FromStatToAttribute")]
    public class ListEnumLinksFromStatToAttribute : ScriptableObject
    {
        [SerializeField] private List<EnumLinkFromStatToAttribute> _enumLinks;

        public AttributeType GetAttributeType(TypeStat typeStat)
        {
            foreach (EnumLinkFromStatToAttribute enumLink in _enumLinks)
            {
                if (enumLink.typeStat == typeStat)
                    return enumLink.attributeType;
            }
            return AttributeType.NONE;
        }
    }
}
