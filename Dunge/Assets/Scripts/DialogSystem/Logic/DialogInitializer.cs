using Scripts.DialogSystem.Structure;
using Scripts.GameLanguage;
using Scripts.StaticData.Dialog;
using System;
using UnityEngine;

namespace Scripts.DialogSystem.Logic
{
    /// <summary>
    /// точка входа в систему диалога
    /// </summary>
    public class DialogInitializer : MonoBehaviour
    {
        public LanguageSettings languageSettings;
        public DialogTracking dialogTracker;

        private bool _isDialogActive = false;

        public void StartDialog(DialogStaticData dialogStaticData)
        {
            if (dialogStaticData != null)
            {
                DialogVariation dialog = dialogStaticData.GetDialogVariationByCurrentLanguage(languageSettings.language);

                if (dialog != null && !_isDialogActive)
                {
                    _isDialogActive = true;

                    dialogTracker.StartDialogTracking(dialog);
                }
            }
        }

        public void InteruptDialog()
        {
            _isDialogActive = false;

            dialogTracker.EndDialogTracking();
        }
    }
}
