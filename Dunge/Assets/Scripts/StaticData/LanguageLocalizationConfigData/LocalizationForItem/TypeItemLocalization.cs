using Scripts.GameMechanic.ItemSystem;
using Scripts.LanguageLocalization;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.LanguageLocalizationConfigData.LocalizationForItem
{
    [Serializable]
    public class TypeItemLocalization
    {
        [SerializeField] private TypeItem TypeItem;
        [SerializeField] private List<LanguageLocalization> _localizations;

        public bool IsEqual(TypeItem typeItem) =>
            TypeItem == typeItem;

        public string GetLocalizationText(Language language)
        {
            foreach (LanguageLocalization localization in _localizations)
                if (localization.Language == language)
                    return localization.LocalizationText;
            return "";
        }
    }
}
