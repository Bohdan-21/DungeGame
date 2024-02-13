using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.LanguageLocalization;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForSkillTree
{
    [CreateAssetMenu(fileName = "LocalizationForAttributeType", menuName = "StaticData/LanguageLocalizationData/LocalizationForAttributeType")]
    public class LocalizationForAttributeType : ScriptableObject
    {
        [SerializeField] private List<AttributeTypeLocalization> _localizations;

        public string GetLocalizationText(AttributeType attributeType, Language language)
        {
            foreach (AttributeTypeLocalization localization in _localizations)
                if (localization.IsEqual(attributeType))
                    return localization.GetLocalizationText(language);
            return "";
        }
    }
}
