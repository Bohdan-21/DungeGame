using Scripts.Data.SaveData;
using Scripts.QuestSystem.QuestVariation.BaseQuest;
using Scripts.QuestSystem.QuestVariation.Data;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.QuestStaticData;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem
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
            foreach (QuestData questData in _playerProgressService.PlayerProgress.ActiveQuestList.QuestDataList)
            {
                GameObject gameObject = SpawnNewQuest(questData.ID);

                gameObject.GetComponent<Quest>().InitializeQuestData(questData);
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
