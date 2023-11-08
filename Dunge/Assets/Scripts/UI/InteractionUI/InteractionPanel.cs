using UnityEngine;

namespace Scripts.UI.Interaction
{
    public class InteractionPanel : MonoBehaviour, IInteractionPanel
    {
        void Start()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}