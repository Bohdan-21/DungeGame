using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameLanguage
{
    public class LanguageSettings : MonoBehaviour, ILanguageSettings
    {
        private Language _language = Language.RU;

        public Language Language { get => _language; }
    }
}