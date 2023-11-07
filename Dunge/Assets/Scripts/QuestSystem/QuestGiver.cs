using Assets.Scripts.QuestSystem;
using UnityEngine;

namespace Scripts.QuestSystem
{
    class QuestGiver : MonoBehaviour
    {
        public KeyCode key;

        public QuestMachine _questMachine;
        
        public int questId;

        private void Start()
        {
            _questMachine = QuestMachine.Instance;
        }

        private void Update()
        {
            if(Input.GetKeyDown(key))
            {
                questId = Random.Range(1, 6);

                _questMachine.ActivateQuest(questId);
            }
        }
    }
}
