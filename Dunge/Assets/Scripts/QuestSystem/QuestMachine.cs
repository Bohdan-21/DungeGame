using Scripts.QuestSystem.QuestVariation;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.QuestStaticData;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem
{
    class QuestMachine
    {
        private QuestList _questList;
        private DiContainer _diContainer;
        private IPlayerProgressService _playerProgressService;

        [Inject]
        private void Construct(QuestList questList, DiContainer diContainer, IPlayerProgressService playerProgressService)
        {
            _questList = questList;
            _diContainer = diContainer;
            _playerProgressService = playerProgressService;
        }

        public void ActivateQuest(int id)
        {
            Quest quest = _questList.GetQuestById(id);

            _diContainer.InstantiatePrefab(quest.gameObject);
        }

    }
}
