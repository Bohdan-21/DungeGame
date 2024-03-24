using Scripts.Services.LanguageService;
using Scripts.StaticData.GameConfigData.GameSystem.Dialog;
using Zenject;

namespace Scripts.GameSystem.DialogSystem.Logic
{
    /// <summary>
    /// точка входа в систему диалога
    /// </summary>
    public class DialogInitializer : IDialogInitializer
    {
        private ILanguageService _languageSettings;
        private IDialogTracking _dialogTracker;
        private bool _isDialogActive = false;

        [Inject]
        private void Construct(ILanguageService languageSettings, IDialogTracking dialogTracker)
        {
            _languageSettings = languageSettings;
            _dialogTracker = dialogTracker;
        }

        public void StartDialog(DialogStaticData dialogStaticData)
        {
            if (dialogStaticData != null)
            {
                DialogVariation dialog = dialogStaticData.GetDialogVariationByCurrentLanguage(_languageSettings.Language);

                if (dialog != null && !_isDialogActive)
                {
                    _isDialogActive = true;

                    _dialogTracker.StartDialogTracking(dialog);
                }
            }
        }

        public void InteruptDialog()
        {
            _isDialogActive = false;

            _dialogTracker.EndDialogTracking();
        }
    }
}
