using Scripts.QuestSystem.QuestVariation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.StaticData.QuestData
{
    [CreateAssetMenu(fileName = "QuestList", menuName = "StaticData/QuestSystem/QuestList")]
    [Serializable]
    class QuestList : ScriptableObject
    {
        [SerializeField] private List<Quest> questList;

        public Quest GetQuestById(int id)
        {
            foreach (Quest quest in questList)
                if (quest.questId == id)
                    return quest;
            return null;
        }
    }
}
