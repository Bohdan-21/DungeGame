using Scripts.QuestSystem.QuestVariation;
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
        private Quest _selectedQuest = null;

        private QuestChannel _questChannel;

        public Quest SelectedQuest { get => _selectedQuest; }
        public List<Quest> AllQuest { get => _allQuest; }

        public event Action UpdateSelectedQuest;

        [Inject]
        private void Construct(QuestChannel questChannel)
        {
            _questChannel = questChannel;

            _questChannel.QuestCreatedEvent += QuesCreatedEvent;
            _questChannel.QuestCompleteEvent += QuestCompleteEvent;
            _questChannel.QuestRefreshEvent += QuestRefreshEvent;
        }

        private void QuesCreatedEvent(Quest quest) => 
            _allQuest.Add(quest);

        private void QuestCompleteEvent(Quest quest)
        {
            _allQuest.Remove(quest);

            if (_selectedQuest == quest)
                _selectedQuest = null;
        }

        private void QuestRefreshEvent(Quest quest) => 
            UpdateSelectedQuest?.Invoke();







    }
}
