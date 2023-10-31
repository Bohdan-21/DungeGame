using Scripts.DialogSystem.Structure;

namespace Scripts.DialogSystem.Logic.UIController
{
    public interface IDialogUI
    {
        void EndDialog();
        void HideUI();
        void Show(Dialog dialog);
        void ShowUI();
    }
}