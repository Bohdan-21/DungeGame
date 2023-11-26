using Scripts.StaticData.Dialog;

namespace Scripts.GameSystem.DialogSystem.Logic
{
    public interface IDialogInitializer
    {
        void InteruptDialog();
        void StartDialog(DialogStaticData dialogStaticData);
    }
}