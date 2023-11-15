using Scripts.QuestSystem.QuestVariation.BaseQuest;
using System;
using System.Collections.Generic;

namespace Scripts.QuestSystem.QuestVariation.Data
{
    [Serializable]
    public class QuestData
    {
        public int ID;
        public string NameQuest;

        public List<Requirement> Requirements;
        public List<Reward> Rewards;
    }
}
