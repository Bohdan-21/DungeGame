using Scripts.DialogSystem.Structure;
using Scripts.GameLanguage;
using Scripts.StaticData.Dialog;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.DialogSystem.Logic
{
    /// <summary>
    /// точка входа в систему диалога
    /// </summary>
    public class DialogInitializer : IDialogInitializer
    {
        public ILanguageSettings _languageSettings;
        public IDialogTracking _dialogTracker;

        private bool _isDialogActive = false;

        [Inject]
        private void Construct(ILanguageSettings languageSettings, IDialogTracking dialogTracker)
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
