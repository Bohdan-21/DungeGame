using UnityEngine;
using Zenject;
using TMPro;
using Scripts.GameSystem.QuestSystem.QuestVariation.BaseQuest;
using Scripts.GameSystem.QuestSystem.Journal;

namespace Scripts.GameSystem.QuestSystem.UI.Tracker
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
            SetDefaultDataForActiveQuest();

            _questJournal.QuestJournalRefreshEvent += QuestJournalRefreshEvent;
        }

        private void OnDestroy()
        {
            _questJournal.QuestJournalRefreshEvent -= QuestJournalRefreshEvent;
        }

        private void QuestJournalRefreshEvent()
        {
            Quest activeQuest = _questJournal.ActiveQuest;

            if (activeQuest != null)
                SetNewDataForActiveQuest(activeQuest);
            else
                SetDefaultDataForActiveQuest();
        }

        private void SetNewDataForActiveQuest(Quest activeQuest)
        {
            _questName.text = activeQuest.QuestData.NameQuest;
            _questProgress.text = activeQuest.Progress;
        }

        private void SetDefaultDataForActiveQuest()
        {
            _questName.text = "Not Active Quest";
            _questProgress.text = "";
        }
    }
}
