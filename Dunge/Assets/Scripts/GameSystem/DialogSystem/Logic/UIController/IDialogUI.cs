using Scripts.StaticData.Dialog;
using Scripts.UI.GameUI.UIHandler;

namespace Scripts.GameSystem.DialogSystem.Logic.UIController
{
    public interface IDialogUI : UIMarker
    {
        void EndDialog();
        void HideUI();
        void Show(Dialog dialog);
        void ShowUI();
    }
}