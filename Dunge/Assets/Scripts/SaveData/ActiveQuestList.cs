using Scripts.QuestSystem.QuestVariation;
using System;
using System.Collections.Generic;

namespace Scripts.Data.SaveData
{
    [Serializable]
    public class ActiveQuestList
    {
        public List<int> IndexQuestList = new List<int>();

        public ActiveQuestList()
        {
            IndexQuestList = new List<int>();
        }
    }
}