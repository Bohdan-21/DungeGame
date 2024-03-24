using Scripts.LanguageLocalization;
using Scripts.SaveData.SettingsData;
using Scripts.Services.SettingsService;
using System;

namespace Scripts.Services.LanguageService
{
    public class LanguageService : ILanguageService, ISettingService
    {
        private ISettingsServiceHandler _settingsServiceHandler;

        public Language Language { get; private set; } = new Language();
        public event Action UpdateLanguageEvent;

        public LanguageService(ISettingsServiceHandler settingsServiceHandler)
        {
            _settingsServiceHandler = settingsServiceHandler;

            _settingsServiceHandler.AddService(this);
        }

        ~LanguageService()
        {
            _settingsServiceHandler.RemoveService(this);
        }

        public void UpdateLanguage(Language language)
        {
            if (language == Language)
                return;
            Language = language;

            UpdateLanguageEvent?.Invoke();
        }


        public void LoadSettings(SettingsData settingsData)
        {
            Language = settingsData.GameLanguage;
        }

        public void UpdateSettings(SettingsData settingsData)
        {
            settingsData.GameLanguage = Language;
        }
    }
}