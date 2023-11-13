using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem.UI
{
    class QuestTracker : MonoBehaviour
    {
        private QuestJournal _questJournal;

        [Inject]
        private void Construct(QuestJournal questJournal) => 
            _questJournal = questJournal;

        private void Start() => 
            _questJournal.UpdateProgressActiveQuest += UpdateSelectedQuest;

        private void OnDestroy() => 
            _questJournal.UpdateProgressActiveQuest -= UpdateSelectedQuest;

        private void UpdateSelectedQuest()
        {
            throw new NotImplementedException();
        }
    }
}
