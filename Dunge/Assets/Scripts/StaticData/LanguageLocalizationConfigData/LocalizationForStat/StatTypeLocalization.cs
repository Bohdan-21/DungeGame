using Scripts.GameSystem.StatsSystem.Type;
using Scripts.LanguageLocalization;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForStat
{
    [Serializable]
    public class StatTypeLocalization
    {
        [SerializeField] private TypeStat TypeStat;
        [SerializeField] private List<LanguageLocalization> _localizations;

        public bool IsEqual(TypeStat typeStat) =>
            TypeStat == typeStat;

        public string GetLocalizationText(Language language)
        {
            foreach (LanguageLocalization localization in _localizations)
                if (localization.Language == language)
                    return localization.LocalizationText;
            return "";
        }
    }
}
