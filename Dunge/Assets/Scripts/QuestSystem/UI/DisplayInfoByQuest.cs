using Scripts.QuestSystem.QuestVariation;
using UnityEngine;
using TMPro;

namespace Scripts.QuestSystem.UI
{
    public class DisplayInfoByQuest : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _questName;
        [SerializeField] private TextMeshProUGUI _questDescription;

        public void ShowInfo(Quest quest)
        {
            _questName.text = quest.nameQuest;
            _questDescription.text = quest.ToString();
        }

        public void CleanInfo()
        {
            _questName.text = _questDescription.text = "";
        }
    }
}
