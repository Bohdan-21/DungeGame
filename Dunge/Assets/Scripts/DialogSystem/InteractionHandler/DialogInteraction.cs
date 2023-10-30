using Scripts.DialogSystem.Logic;
using Scripts.StaticData.Dialog;
using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(DialogQueueHandler))]
    class DialogInteraction : MonoBehaviour
    {
        public KeyCode Key;
        public DialogInitializer dialogController;
        public DialogQueueHandler dialogQueueHandler;

        private int currentDialog = 0;
        public DialogStaticData sec;
        public DialogStaticData def;

        private void Update()
        {
            if(Input.GetKeyDown(Key))
            {
                dialogController.StartDialog(dialogQueueHandler.GetDefaultDialog());
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
