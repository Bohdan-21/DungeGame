using UnityEngine;
using TMPro;
using Zenject;
using Scripts.LanguageLocalization.Service;

namespace Assets.Scripts.LanguageLocalization.Handler
{
    class TextLocalization : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textForLocalization;
        [SerializeField] private LocalizationData _localizationData;

        private ILanguageSettings _languageSettings;

        [Inject]
        private void Construct(ILanguageSettings languageSettings) => 
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
