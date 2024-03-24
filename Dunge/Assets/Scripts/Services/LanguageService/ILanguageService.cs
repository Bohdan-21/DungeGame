using Scripts.LanguageLocalization;
using System;

namespace Scripts.Services.LanguageService
{
    public interface ILanguageService
    {
        event Action UpdateLanguageEvent;

        Language Language { get; }

        void UpdateLanguage(Language language);
    }
}