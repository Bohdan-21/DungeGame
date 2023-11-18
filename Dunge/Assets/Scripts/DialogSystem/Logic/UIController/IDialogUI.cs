using Scripts.StaticData.Dialog;

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