using Scripts.QuestSystem.QuestVariation.BaseQuest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem
{
    class QuestJournal
    {
        private List<Quest> _allQuest = new List<Quest>();
        private Quest _activeQuest = null;

        private QuestChannel _questChannel;

        public Quest ActiveQuest { get => _activeQuest; }
        public List<Quest> AllQuest { get => _allQuest; }

        public event Action RefreshActiveQuestEvent;
        public event Action ActiveQuestCompleteEvent;

        [Inject]
        private void Construct(QuestChannel questChannel)
        {
            _questChannel = questChannel;

            _questChannel.QuestCreatedEvent += QuesCreatedEvent;
            _questChannel.QuestCompleteEvent += QuestCompleteEvent;
            _questChannel.QuestRefreshEvent += RefreshActiveQuest;
        }

        public void UpdateActiveQuest(Quest newQuest)
        {
            StopTrackingActiveQuest();
            StartTrackingNewActiveQuest(newQuest);
            RefreshActiveQuest();
        }

        private void StopTrackingActiveQuest()
        {
            if (_activeQuest != null)
                _activeQuest.StopTrackingQuest();
        }

        private void StartTrackingNewActiveQuest(Quest newQuest)
        {
            _activeQuest = newQuest;
            _activeQuest.StartTrackingQuest();
        }

        private void QuesCreatedEvent(Quest quest) => 
            _allQuest.Add(quest);

        private void QuestCompleteEvent(Quest quest)
        {
            _allQuest.Remove(quest);

            if (_activeQuest == quest)
                _activeQuest = null;

            ActiveQuestComplete();
        }

        private void RefreshActiveQuest()
        {
            RefreshActiveQuestEvent?.Invoke();
        }

        private void ActiveQuestComplete()
        {
            ActiveQuestCompleteEvent?.Invoke();
        }
    }
}
