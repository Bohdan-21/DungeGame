using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Scripts.DialogSystem.Logic.UIController
{
    public class WaitingButton : MonoBehaviour
    {
        public Button waitingButton;

        public void ActivateAndAddListener(UnityAction callback)
        {
            waitingButton.gameObject.SetActive(true);

            waitingButton.onClick.AddListener(callback);
        }

        public void DeactivateAndRemoveAllListener()
        {
            waitingButton.onClick.RemoveAllListeners();

            waitingButton.gameObject.SetActive(false);
        }
    }
}