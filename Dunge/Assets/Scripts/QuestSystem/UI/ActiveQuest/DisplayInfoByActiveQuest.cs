using System;
using UnityEngine;
using Zenject;
using TMPro;
using Scripts.QuestSystem.QuestVariation.BaseQuest;
using Scripts.QuestSystem.Journal;

namespace Scripts.QuestSystem.UI.ActiveQuest
{
    public class DisplayInfoByActiveQuest : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameActiveQuest;

        private IQuestJournal _questJournal;

        [Inject]
        private void Construct(IQuestJournal questJournal) =>
            _questJournal = questJournal;

        public void ShowActiveQuest()
        {
            if (_questJournal.ActiveQuest != null)
                _nameActiveQuest.text = _questJournal.ActiveQuest.ToString();
            else
                _nameActiveQuest.text = "";
        }

        public void UpdateActiveQuest(Quest newActiveQuest)
        {
            _questJournal.UpdateActiveQuest(newActiveQuest);
            _nameActiveQuest.text = newActiveQuest.ToString();
        }
    }
}
