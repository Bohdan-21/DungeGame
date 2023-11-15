using Scripts.QuestSystem.QuestVariation.Data;
using System;
using System.Collections.Generic;

namespace Scripts.Data.SaveData
{
    [Serializable]
    public class ActiveQuestList
    {
        public List<QuestData> QuestDataList = new List<QuestData>();

        public ActiveQuestList()
        {
            QuestDataList = new List<QuestData>();
        }

        public void Clear()
        {
            QuestDataList.Clear();
        }
    }
}