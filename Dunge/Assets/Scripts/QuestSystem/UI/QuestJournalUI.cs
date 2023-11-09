using Scripts.QuestSystem.QuestVariation;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem.UI
{

    class QuestJournalUI : MonoBehaviour, IQuestJournalUI
    {
        [SerializeField] private KeyCode QuestJournalUIButton;

        [SerializeField] private GameObject RootComponent;
        [SerializeField] private GameObject QuestItemListPrefab;
        [SerializeField] private Transform Content;
        
        private bool _isShow;
        private QuestJournal _questJournal;
        private List<GameObject> _spawnedQuestList = new List<GameObject>();


        [Inject]
        private void Construct(QuestJournal questJournal)
        {
            _questJournal = questJournal;
        }

        private void Start()
        {
            Hide();
        }

        private void Update()
        {
            if (Input.GetKeyDown(QuestJournalUIButton))
            {
                if (_isShow)
                    Hide();
                else
                    Show();
            }
        }

        public void Show()
        {
            RootComponent.SetActive(true);

            _isShow = true;

            //ShowSelectedQuest();

            SpawnAllAvailableQuest();
        }

        public void Hide()
        {
            RootComponent.SetActive(false);

            _isShow = false;

            DestroyAllSpawnedQuest();
        }

        private void ShowSelectedQuest()
        {
            throw new NotImplementedException();
        }

        private void SpawnAllAvailableQuest()
        {
            foreach (Quest quest in _questJournal.AllQuest)
            {
                GameObject questItem = Instantiate(QuestItemListPrefab, Content);

                questItem.GetComponent<QuestDisplayer>().Initialize(quest);
            }
        }

        private void DestroyAllSpawnedQuest()
        {
            foreach (GameObject listItem in _spawnedQuestList)
                Destroy(listItem);

            _spawnedQuestList.Clear();
        }


    }
}
