using UnityEngine;
using TMPro;
using Scripts.GameSystem.QuestSystem.QuestVariation.BaseQuest;

namespace Scripts.GameSystem.QuestSystem.UI.QuestInfoDisplayer
{
    public class DisplayInfoByQuest : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _questName;
        [SerializeField] private TextMeshProUGUI _questDescription;

        public void ShowInfo(Quest quest)
        {
            _questName.text = quest.QuestData.NameQuest;
            _questDescription.text = quest.ToString();
        }

        public void CleanInfo()
        {
            _questName.text = _questDescription.text = "";
        }
    }
}
