using System;
using UnityEngine;
using Scripts.QuestSystem.QuestVariation;

namespace Scripts.QuestSystem
{
    public class QuestChannel
    {
        public event Action<Quest> QuestCompleteEvent;
        public event Action<Quest> QuestRefreshEvent;
        public event Action<Quest> QuestActivateEvent;

        public void CompleteQuest(Quest quest)
        {
            QuestCompleteEvent?.Invoke(quest);
        }

        public void RefreshQuest(Quest quest)
        {
            QuestRefreshEvent?.Invoke(quest);
        }

        public void ActivateQuest(Quest quest)
        {
            QuestActivateEvent?.Invoke(quest);
        }
    }
}
