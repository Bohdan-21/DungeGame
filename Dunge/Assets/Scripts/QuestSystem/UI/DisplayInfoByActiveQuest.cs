using Scripts.QuestSystem.QuestVariation;
using System;
using UnityEngine;
using Zenject;
using TMPro;

namespace Scripts.QuestSystem.UI
{
    public class DisplayInfoByActiveQuest : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameActiveQuest;

        private QuestJournal _questJournal;

        [Inject]
        private void Construct(QuestJournal questJournal) => 
            _questJournal = questJournal;

        public void ShowActiveQuest()
        {
            if (_questJournal.ActiveQuest != null)
                _nameActiveQuest.text = _questJournal.ActiveQuest.ToString();
        }

        public void UpdateActiveQuest(Quest newActiveQuest)
        {
            _questJournal.UpdateActiveQuest(newActiveQuest);
            _nameActiveQuest.text = newActiveQuest.ToString();
        }
    }
}
