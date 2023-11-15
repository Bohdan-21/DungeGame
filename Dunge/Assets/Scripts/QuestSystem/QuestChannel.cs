using System;
using UnityEngine;
using Scripts.QuestSystem.QuestVariation.BaseQuest;

namespace Scripts.QuestSystem
{
    public class QuestChannel
    {
        public event Action<Quest> QuestCompleteEvent;
        public event Action QuestRefreshEvent;
        public event Action<Quest> QuestCreatedEvent;

        public void CompleteQuest(Quest quest)
        {
            QuestCompleteEvent?.Invoke(quest);
        }

        public void RefreshActiveQuest()
        {
            QuestRefreshEvent?.Invoke();
        }

        public void ActivateQuest(Quest quest)
        {
            QuestCreatedEvent?.Invoke(quest);
        }
    }
}
