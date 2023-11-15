using Scripts.QuestSystem.QuestVariation.BaseQuest;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem.UI
{
    public class QuestListSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject QuestItemListPrefab;
        [SerializeField] private Transform Content;
        [SerializeField] private DisplayInfoBySelectedQuest _setSelectedQuest;

        private List<QuestDisplayer> _spawnedQuestList = new List<QuestDisplayer>();
        private QuestJournal _questJournal;

        [Inject]
        private void Construct(QuestJournal questJournal) => 
            _questJournal = questJournal;

        public void Show() => 
            SpawnAllActiveQuest();

        public void Hide()
        {
            DestroyAllSpawnedQuest();

            _setSelectedQuest.ResetSelectedQuest();
        }

        private void SpawnAllActiveQuest()
        {
            foreach (Quest quest in _questJournal.AllQuest)
            {
                QuestDisplayer questItem = Instantiate(QuestItemListPrefab, Content).GetComponent<QuestDisplayer>();

                questItem.Initialize(quest, callback: SelectedQuest);

                _spawnedQuestList.Add(questItem);
            }
        }

        private void DestroyAllSpawnedQuest()
        {
            foreach (QuestDisplayer listItem in _spawnedQuestList)
                Destroy(listItem.gameObject);

            _spawnedQuestList.Clear();
        }

        private void SelectedQuest(Quest quest) => 
            _setSelectedQuest.SetNewSelectedQuest(quest);
    }
}
