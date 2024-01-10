using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.LanguageLocalization;

namespace Assets.Scripts.LanguageLocalization.Handler
{
    [Serializable]
    class LocalizationData
    {
        [Serializable]
        class LocalizationText
        {
            public Language language;
            public string text;
        }

        [SerializeField] private List<LocalizationText> _localizations;

        public string GetLocalization(Language language)
        {
            foreach (LocalizationText localizationText in _localizations)
                if (localizationText.language == language)
                    return localizationText.text;
            return "";
        }
    }
}
