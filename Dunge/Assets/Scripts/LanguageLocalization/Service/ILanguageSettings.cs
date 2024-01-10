using System;

namespace Scripts.LanguageLocalization.Service
{
    public interface ILanguageSettings
    {
        event Action UpdateLanguageEvent;

        Language Language { get; }

        void UpdateLanguage(Language language);
    }
}