using Scripts.GameSystem.QuestSystem.QuestVariation.BaseQuest;
using System;
using System.Collections.Generic;

namespace Scripts.GameSystem.QuestSystem.Journal
{
    interface IQuestJournal
    {
        Quest ActiveQuest { get; }
        List<Quest> AllQuest { get; }

        event Action QuestJournalRefreshEvent;

        void UpdateActiveQuest(Quest newQuest);
    }
}