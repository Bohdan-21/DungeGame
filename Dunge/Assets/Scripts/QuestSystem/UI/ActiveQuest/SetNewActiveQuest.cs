using Scripts.QuestSystem.QuestVariation.BaseQuest;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.QuestSystem.UI.ActiveQuest
{
    public class SetNewActiveQuest : MonoBehaviour
    {
        [SerializeField] private Button _setButton;
        [SerializeField] private DisplayInfoByActiveQuest _displayInfoByActiveQuest;

        private Quest _newActiveQuest;

        public void SetActiveQuest(Quest quest)
        {
            _newActiveQuest = quest;
            _setButton.interactable = true;
        }

        public void CleanNewActiveQuest()
        {
            _newActiveQuest = null;
            _setButton.interactable = false;
        }

        public void ClickToSetNewActiveQuest()
        {
            _displayInfoByActiveQuest.UpdateActiveQuest(_newActiveQuest);
        }
    }
}
