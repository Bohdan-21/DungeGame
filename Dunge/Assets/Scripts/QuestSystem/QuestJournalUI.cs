using Scripts.QuestSystem.QuestVariation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.QuestSystem
{
    class QuestJournalUI : MonoBehaviour
    {
        public KeyCode QuestJournalUIButton;

        public QuestJournal _questJournal;

        public GameObject RootComponent;
        public GameObject QuestItemListPrefab;
        public Transform Content;
        private bool _isShow;

        private List<GameObject> _spawnedQuestList = new List<GameObject>();

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

        private void Show()
        {
            RootComponent.SetActive(true);

            _isShow = true;

            SpawnAllAvailableQuest();

            ShowSelectedQuest();
        }

        private void Hide()
        {
            RootComponent.SetActive(false);

            _isShow = false;

            DestroyAllSpawnedQuest();
        }

        private void SpawnAllAvailableQuest()
        {
            throw new NotImplementedException();
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
