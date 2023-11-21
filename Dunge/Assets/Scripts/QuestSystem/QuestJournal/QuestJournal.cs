using Scripts.Data.SaveData;
using Scripts.QuestSystem.Channel;
using Scripts.QuestSystem.QuestVariation.BaseQuest;
using Scripts.Services.PlayerProgressService;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem.Journal
{
    class QuestJournal : MonoBehaviour, IPlayerProgressUpdater, IQuestJournal
    {
        private List<Quest> _allQuest = new List<Quest>();
        private Quest _activeQuest = null;

        private QuestChannel _questChannel;
        private IPlayerProgressService _playerProgressService;

        public Quest ActiveQuest { get => _activeQuest; }
        public List<Quest> AllQuest { get => _allQuest; }

        public event Action QuestJournalRefreshEvent;

        [Inject]
        private void Construct(QuestChannel questChannel, IPlayerProgressService playerProgressService)
        {
            _questChannel = questChannel;
            _playerProgressService = playerProgressService;

            _questChannel.QuestCreatedEvent += QuesCreatedEvent;
            _questChannel.QuestCompleteEvent += QuestCompleteEvent;
            _questChannel.QuestRefreshEvent += QuestJournalRefresh;
        }

        private void Start()
        {
            _playerProgressService.AddProgressUpdater(this);
        }

        public void UpdateActiveQuest(Quest newQuest)
        {
            StopTrackingActiveQuest();
            StartTrackingNewActiveQuest(newQuest);
            QuestJournalRefresh();
        }

        private void StopTrackingActiveQuest()
        {
            if (_activeQuest != null)
            {
                _activeQuest.StopTrackingQuest();
                _allQuest.Add(_activeQuest);
            }
        }

        private void StartTrackingNewActiveQuest(Quest newQuest)
        {
            _activeQuest = newQuest;
            _allQuest.Remove(newQuest);
            _activeQuest.StartTrackingQuest();
        }

        private void QuesCreatedEvent(Quest quest)
        {
            if (_activeQuest == null)
            {
                _activeQuest = quest;
                _activeQuest.StartTrackingQuest();
            }
            else
                _allQuest.Add(quest);

            QuestJournalRefresh();
        }

        private void QuestCompleteEvent(Quest quest)
        {
            _allQuest.Remove(quest);

            if (_activeQuest == quest)
                _activeQuest = null;

            QuestJournalRefresh();
        }

        private void QuestJournalRefresh() => 
            QuestJournalRefreshEvent?.Invoke();

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.ActiveQuestList.ActiveQuest = _activeQuest.QuestData;

            foreach (Quest quest in _allQuest)
                playerProgress.ActiveQuestList.QuestDataList.Add(quest.QuestData);
        }
    }
}
