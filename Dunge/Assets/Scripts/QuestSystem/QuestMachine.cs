using Scripts.QuestSystem.QuestVariation;
using Scripts.StaticData.QuestData;
using UnityEngine;

namespace Assets.Scripts.QuestSystem
{
    class QuestMachine : MonoBehaviour
    {
        public static QuestMachine Instance;

        public QuestList questList;

        private void Awake()
        {
            Instance = this;
        }

        public void ActivateQuest(int id)
        {
            Quest quest = questList.GetQuestById(id);

            Instantiate(quest);
        }
    }
}
