using Scripts.QuestSystem.QuestVariation.BaseQuest;
using System;
using System.Collections.Generic;

namespace Scripts.QuestSystem.Journal
{
    interface IQuestJournal
    {
        Quest ActiveQuest { get; }
        List<Quest> AllQuest { get; }

        event Action ActiveQuestCompleteEvent;
        event Action RefreshActiveQuestEvent;

        void UpdateActiveQuest(Quest newQuest);
    }
}