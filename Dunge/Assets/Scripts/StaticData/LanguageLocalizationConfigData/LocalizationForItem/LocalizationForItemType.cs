using Scripts.GameMechanic.ItemSystem;
using Scripts.LanguageLocalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForItem
{
    [CreateAssetMenu(fileName = "LocalizationForItemType", menuName = "StaticData/LanguageLocalizationData/LocalizationForItemType")]
    public class LocalizationForItemType : ScriptableObject
    {
        [SerializeField] private List<TypeItemLocalization> _localizations;

        public string GetLocalizationText(TypeItem typeItem, Language language)
        {
            foreach (TypeItemLocalization localization in _localizations)
                if (localization.IsEqual(typeItem))
                    return localization.GetLocalizationText(language);
            return "";
        }
    }
}
