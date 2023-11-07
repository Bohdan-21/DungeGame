using Scripts.QuestSystem.QuestVariation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.QuestSystem
{
    class QuestJournal : MonoBehaviour
    {
        public List<Quest> allQuest = new List<Quest>();
        public Quest _selectedQuest;

        public QuestChannel _questChannel;

        public event Action UpdateJournal;


        private void Start()
        {
            Construct();
        }

        private void Construct()
        {
            _questChannel = QuestChannel.Instance;

            _questChannel.QuestActivateEvent += QuestActivateEvent;
            _questChannel.QuestCompleteEvent += QuestCompleteEvent;
            _questChannel.QuestRefreshEvent += QuestRefreshEvent;
        }

        private void QuestRefreshEvent(Quest quest)
        {
            Debug.Log("Refresh quest:" + quest.ToString());
        }

        private void QuestCompleteEvent(Quest quest)
        {
            allQuest.Remove(quest);

            if (allQuest.Count > 0)
                SetDefaultQuest();
        }

        private void QuestActivateEvent(Quest quest)
        {
            allQuest.Add(quest);
            
            SetDefaultQuest();
        }

        private void SetDefaultQuest()
        {
            _selectedQuest = allQuest[0];
        }

        private void InvokeUpdateJournal()
        {
            UpdateJournal?.Invoke();
        }
    }
}
