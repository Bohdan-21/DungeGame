using Scripts.QuestSystem.QuestVariation.BaseQuest;
using UnityEngine;

namespace Scripts.QuestSystem.UI
{
    public class DisplayInfoBySelectedQuest : MonoBehaviour
    {
        [SerializeField] private DisplayInfoByQuest _displayInfoByQuest;
        [SerializeField] private SetNewActiveQuest _setNewActiveQuest;

        private void Start() => 
            ResetSelectedQuest();

        public void SetNewSelectedQuest(Quest quest)
        {
            _displayInfoByQuest.ShowInfo(quest);
            _setNewActiveQuest.SetActiveQuest(quest);
        }

        public void ResetSelectedQuest()
        {
            _displayInfoByQuest.CleanInfo();
            _setNewActiveQuest.CleanNewActiveQuest();
        }
    }
}
