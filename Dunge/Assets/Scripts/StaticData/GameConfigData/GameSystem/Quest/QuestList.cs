using Scripts.GameSystem.QuestSystem.QuestVariation.BaseQuest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.GameSystem.QuestStaticData
{
    [CreateAssetMenu(fileName = "QuestList", menuName = "StaticData/GameConfigData/GameSystem/Quest/QuestList")]
    [Serializable]
    public class QuestList : ScriptableObject
    {
        [SerializeField] private List<Quest> questList;

        public Quest GetQuestById(int id)
        {
            foreach (Quest quest in questList)
                if (quest.QuestData.ID == id)
                    return quest;
            return null;
        }
    }
}
