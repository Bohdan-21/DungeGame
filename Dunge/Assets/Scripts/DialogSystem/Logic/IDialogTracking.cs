using Scripts.StaticData.Dialog;

namespace Scripts.DialogSystem.Logic
{
    public interface IDialogTracking
    {
        void DialogResponce(int codeResponce);
        void EndDialogTracking();
        void StartDialogTracking(DialogVariation dialog);
    }
}