using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using TMPro;
using Scripts.QuestSystem.QuestVariation;
using Scripts.QuestSystem.Journal;

namespace Scripts.QuestSystem.UI.Tracker
{
    public class QuestTracker : MonoBehaviour, IQuestTracker
    {
        [SerializeField] private TextMeshProUGUI _questName;
        [SerializeField] private TextMeshProUGUI _questProgress;

        private IQuestJournal _questJournal;

        [Inject]
        private void Construct(IQuestJournal questJournal)
        {
            _questJournal = questJournal;
        }

        private void Start()
        {
            ActiveQuestComplete();

            _questJournal.RefreshActiveQuestEvent += UpdateActiveQuest;
            _questJournal.ActiveQuestCompleteEvent += ActiveQuestComplete;
        }

        private void OnDestroy()
        {
            _questJournal.RefreshActiveQuestEvent -= UpdateActiveQuest;
            _questJournal.ActiveQuestCompleteEvent -= ActiveQuestComplete;
        }

        private void UpdateActiveQuest()
        {
            _questName.text = _questJournal.ActiveQuest.QuestData.NameQuest;
            _questProgress.text = _questJournal.ActiveQuest.Progress;
        }

        private void ActiveQuestComplete()
        {
            _questName.text = "Not Active Quest";
            _questProgress.text = "";
        }
    }
}
