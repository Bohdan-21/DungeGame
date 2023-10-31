using Scripts.StaticData.Dialog;

namespace Scripts.DialogSystem.Logic
{
    public interface IDialogInitializer
    {
        void InteruptDialog();
        void StartDialog(DialogStaticData dialogStaticData);
    }
}