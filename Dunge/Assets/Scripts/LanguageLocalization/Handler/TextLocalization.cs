using UnityEngine;
using TMPro;
using Zenject;
using Scripts.Services.LanguageService;

namespace Assets.Scripts.LanguageLocalization.Handler
{
    class TextLocalization : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textForLocalization;
        [SerializeField] private LocalizationData _localizationData;

        private ILanguageService _languageSettings;

        [Inject]
        private void Construct(ILanguageService languageSettings) => 
            _languageSettings = languageSettings;

        private void Start()
        {
            _languageSettings.UpdateLanguageEvent += UpdateLanguage;
            UpdateLanguage();
        }

        private void OnDestroy() => 
            _languageSettings.UpdateLanguageEvent -= UpdateLanguage;

        private void UpdateLanguage()
        {
            _textForLocalization.text = _localizationData.GetLocalization(_languageSettings.Language);
        }
    }
}
