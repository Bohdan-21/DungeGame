using Scripts.StaticData.Dialog;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Scripts.GameSystem.DialogSystem.DialogHandler
{
    public class DialogQueueHandler : MonoBehaviour
    {
        [SerializeField] private List<DialogStaticData> _dialogList = new List<DialogStaticData>();

        public event Action SpeakEvent;

        public DialogStaticData GetDefaultDialog()
        {
            if (_dialogList != null && _dialogList.Count != 0)
            {
                DialogStaticData dialogStaticData = _dialogList[0];

                if (dialogStaticData.ShowOneTime)
                    _dialogList.RemoveAt(0);

                SpeakEvent?.Invoke();

                return dialogStaticData;
            }
            return null;
        }

        public void SetDefaultDialog(DialogStaticData newDefaultDialog)
        {
            List<DialogStaticData> newDialogList = new List<DialogStaticData>();

            newDialogList.Add(newDefaultDialog);

            foreach (DialogStaticData data in _dialogList)
                newDialogList.Add(data);

            _dialogList.Clear();

            _dialogList = newDialogList;
        }

        public void AddNewDialogInEnd(DialogStaticData newDialog)
        {
            _dialogList.Add(newDialog);
        }
    }
}
