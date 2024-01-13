using Scripts.GameSystem.QuestSystem.QuestVariation.BaseQuest;
using Scripts.GameSystem.QuestSystem.QuestVariation.Data;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.GameConfigData.GameSystem.QuestStaticData;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.QuestSystem.Factory
{
    public class QuestFactory
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

        public void SpawnNewQuestByID(int id) =>
            SpawnNewQuest(id);

        public void RespawnSavedQuest()
        {
            RespawnActiveQuest();
            RespawnNotActiveList();
        }

        private void RespawnActiveQuest()
        {
            if (_playerProgressService.PlayerProgress.ActiveQuestList.ActiveQuest == null) return;

            QuestData questDataActiveQuest = _playerProgressService.PlayerProgress.ActiveQuestList.ActiveQuest;

            GameObject activeQuest = SpawnNewQuest(questDataActiveQuest.ID);

            activeQuest.GetComponent<Quest>().InitializeQuestData(questDataActiveQuest);
        }

        private void RespawnNotActiveList()
        {
            foreach (QuestData questData in _playerProgressService.PlayerProgress.ActiveQuestList.QuestDataList)
            {
                GameObject unactiveQuest = SpawnNewQuest(questData.ID);

                unactiveQuest.GetComponent<Quest>().InitializeQuestData(questData);
            }
        }

        private GameObject SpawnNewQuest(int id)
        {
            Quest quest = GetQuestById(id);

            return _diContainer.InstantiatePrefab(quest.gameObject);
        }

        private Quest GetQuestById(int id) =>
            _questList.GetQuestById(id);
    }
}
