using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.LanguageLocalization.Service
{
    public class LanguageSettings : ILanguageSettings
    {
        private Language _language = Language.ENG;
        public Language Language { get => _language; set => _language = value; }

        public event Action UpdateLanguageEvent;

        public void UpdateLanguage(Language language)
        {
            if (language == _language)
                return;
            _language = language;

            UpdateLanguageEvent?.Invoke();
        }
    }
}