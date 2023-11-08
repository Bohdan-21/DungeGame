using Scripts.QuestSystem;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem
{
    class QuestGiver : MonoBehaviour
    {
        public KeyCode key;
        public int questId;

        private QuestMachine _questMachine;
        
        [Inject]
        private void Construct(QuestMachine questMachine)
        {
            _questMachine = questMachine;
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
