using Scripts.GameSystem.StatsSystem.Type;
using Scripts.LanguageLocalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForStat
{
    [CreateAssetMenu(fileName = "LocalizationForStatType", menuName = "StaticData/LanguageLocalizationData/LocalizationForStatType")]
    public class LocalizationForStatType : ScriptableObject
    {
        [SerializeField] private List<StatTypeLocalization> _localizations;

        public string GetLocalizationText(TypeStat typeStat, Language language)
        {
            foreach (StatTypeLocalization localization in _localizations)
                if (localization.IsEqual(typeStat))
                    return localization.GetLocalizationText(language);
            return "";
        }
    }
}
