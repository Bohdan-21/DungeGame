using Scripts.QuestSystem.QuestVariation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem
{

    class QuestJournalUI : MonoBehaviour, IQuestJournalUI
    {
        public KeyCode QuestJournalUIButton;

        public GameObject RootComponent;
        public GameObject QuestItemListPrefab;
        public Transform Content;
        private bool _isShow;
        private QuestJournal _questJournal;
        private DiContainer _diContainer;
        private List<GameObject> _spawnedQuestList = new List<GameObject>();


        [Inject]
        private void Construct(QuestJournal questJournal, DiContainer diContainer)
        {
            _questJournal = questJournal;
            _diContainer = diContainer;
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

            SpawnAllAvailableQuest();

            //ShowSelectedQuest();
        }

        public void Hide()
        {
            RootComponent.SetActive(false);

            _isShow = false;

            //DestroyAllSpawnedQuest();
        }

        private void SpawnAllAvailableQuest()
        {
            foreach(Quest quest in _questJournal.allQuest)
            {
                GameObject questItem = _diContainer.InstantiatePrefab(QuestItemListPrefab);
                
                questItem.GetComponent<QuestDisplayer>().Initialize(quest);

                questItem.transform.parent = Content;
            }
        }

        private void DestroyAllSpawnedQuest()
        {
            throw new NotImplementedException();
        }

        private void ShowSelectedQuest()
        {
            throw new NotImplementedException();
        }



    }
}
