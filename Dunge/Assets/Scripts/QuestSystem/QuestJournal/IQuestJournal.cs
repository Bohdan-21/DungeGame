using Scripts.QuestSystem.QuestVariation.BaseQuest;
using System;
using System.Collections.Generic;

namespace Scripts.QuestSystem.Journal
{
    interface IQuestJournal
    {
        Quest ActiveQuest { get; }
        List<Quest> AllQuest { get; }

        event Action QuestJournalRefreshEvent;

        void UpdateActiveQuest(Quest newQuest);
    }
}