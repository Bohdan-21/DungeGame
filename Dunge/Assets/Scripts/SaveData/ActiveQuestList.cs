using Scripts.GameSystem.QuestSystem.QuestVariation.Data;
using System;
using System.Collections.Generic;

namespace Scripts.SaveData
{
    [Serializable]
    public class ActiveQuestList
    {
        public QuestData ActiveQuest;
        public List<QuestData> QuestDataList = new List<QuestData>();

        public ActiveQuestList()
        {
            QuestDataList = new List<QuestData>();
        }

        public void Clear()
        {
            ActiveQuest = null;
            QuestDataList.Clear();
        }
    }
}