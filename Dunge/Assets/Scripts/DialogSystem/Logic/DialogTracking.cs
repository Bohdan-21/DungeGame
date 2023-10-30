using Scripts.DialogSystem.Logic.UIController;
using Scripts.DialogSystem.Structure;
using System;
using UnityEngine;

namespace Scripts.DialogSystem.Logic
{
    /// <summary>
    ///это может быть обычный класс который просто отслежывает текущее состояние 
    ///диалога, и побольшей степени он является просто связующим звеном
    /// </summary>
    public class DialogTracking : MonoBehaviour
    {
        public DialogUI dialogUI;
        public DialogInitializer dialogInitializer;

        private DialogVariation _dialogVariation = null;

        public void StartDialogTracking(DialogVariation dialog)
        {
            _dialogVariation = dialog;

            ShowFirstDialog();
        }

        private void ShowFirstDialog()
        {
            Dialog dialog = _dialogVariation.dialogList.dialogs[0];

            dialogUI.ShowUI();

            dialogUI.Show(dialog);
        }

        public void DialogResponce(int codeResponce)
        {
            if (codeResponce == -1)
                dialogInitializer.InteruptDialog();
            else
            {
                Dialog dialog = FindDialogById(codeResponce);

                if (dialog == null)
                    dialogInitializer.InteruptDialog();
                else
                    dialogUI.Show(dialog);
            }
        }

        private Dialog FindDialogById(int codeResponce)
        {
            int count = _dialogVariation.dialogList.dialogs.Count;

            for (int i = 0; i < count; i++)
                if (_dialogVariation.dialogList.dialogs[i].id == codeResponce)
                    return _dialogVariation.dialogList.dialogs[i];
            return null;
        }

        public void EndDialogTracking()
        {
            _dialogVariation = null;

            dialogUI.HideUI();
        }
    }
}
