using Scripts.QuestSystem.QuestVariation.Data;
using System;
using System.Collections.Generic;

namespace Scripts.Data.SaveData
{
    [Serializable]
    public class ActiveQuestList
    {
        public List<int> QuestDataList = new List<int>();

        public ActiveQuestList()
        {
            QuestDataList = new List<int>();
        }

        public void Clear()
        {
            QuestDataList.Clear();
        }
    }
}