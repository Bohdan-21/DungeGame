using Scripts.QuestSystem.QuestVariation;
using Scripts.StaticData.QuestStaticData;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem
{
    class QuestMachine
    {
        private QuestList _questList;
        private DiContainer _diContainer;

        [Inject]
        private void Construct(QuestList questList, DiContainer diContainer)
        {
            _questList = questList;
            _diContainer = diContainer;
        }

        public void ActivateQuest(int id)
        {
            Quest quest = _questList.GetQuestById(id);

            _diContainer.InstantiatePrefab(quest.gameObject);
        }
    }
}
