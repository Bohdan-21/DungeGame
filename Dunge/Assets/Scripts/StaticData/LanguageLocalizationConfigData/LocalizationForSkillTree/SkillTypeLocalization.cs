using Scripts.GameSystem.SkillTreeSystem.Type;
using Scripts.LanguageLocalization;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForSkillTree
{
    [Serializable]
    public class SkillTypeLocalization
    {
        [SerializeField] private SkillType SkillType;
        [SerializeField] private List<LanguageLocalization> _localizations;

        public bool IsEqual(SkillType skillType) =>
            SkillType == skillType;

        public string GetLocalizationText(Language language)
        {
            foreach (LanguageLocalization localization in _localizations)
                if (localization.Language == language)
                    return localization.LocalizationText;
            return "";
        }
    }
}
