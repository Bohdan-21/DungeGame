using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.LanguageLocalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForSkillTree
{
    [CreateAssetMenu(fileName = "LocalizationForSkillType", menuName = "StaticData/LanguageLocalizationData/LocalizationForSkillType")]
    public class LocalizationForSkillType : ScriptableObject
    {
        [SerializeField] private List<SkillTypeLocalization> _localizations;

        public string GetLocalizationText(SkillType skillType, Language language)
        {
            foreach (SkillTypeLocalization localization in _localizations)
                if (localization.IsEqual(skillType))
                    return localization.GetLocalizationText(language);
            return "";
        }
    }
}
