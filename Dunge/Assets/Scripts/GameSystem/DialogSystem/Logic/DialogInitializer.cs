using Scripts.Services.InputBlockerService;
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
        private IInputBlockerService _inputBlockerService;

        private bool _isDialogActive = false;

        [Inject]
        private void Construct(ILanguageService languageSettings, IDialogTracking dialogTracker, 
                               IInputBlockerService inputBlockerService)
        {
            _languageSettings = languageSettings;
            _dialogTracker = dialogTracker;
            _inputBlockerService = inputBlockerService;
        }

        public void StartDialog(DialogStaticData dialogStaticData)
        {
            if (dialogStaticData != null)
            {
                _inputBlockerService.BlockAllInput();

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

            _inputBlockerService.UnBlockAllInput();
        }
    }
}
