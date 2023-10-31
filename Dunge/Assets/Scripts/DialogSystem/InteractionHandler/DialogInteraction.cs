using Scripts.DialogSystem.Logic;
using Scripts.StaticData.Dialog;
using UnityEngine;
using Zenject;

namespace Scripts
{
    [RequireComponent(typeof(DialogQueueHandler))]
    class DialogInteraction : MonoBehaviour
    {
        public KeyCode Key;
        public IDialogInitializer _dialogController;
        public DialogQueueHandler dialogQueueHandler;

        private int currentDialog = 0;
        public DialogStaticData sec;
        public DialogStaticData def;

        [Inject]
        private void Construct(IDialogInitializer dialogController)
        {
            _dialogController = dialogController;
        }

        private void Update()
        {
            if(Input.GetKeyDown(Key))
            {
                _dialogController.StartDialog(dialogQueueHandler.GetDefaultDialog());
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(currentDialog == 0)
                {
                    dialogQueueHandler.AddNewDialogInEnd(sec);
                }
                else if(currentDialog == 1)
                {
                    dialogQueueHandler.SetDefaultDialog(def);
                }
                currentDialog++;
            }
        }
    }
}
