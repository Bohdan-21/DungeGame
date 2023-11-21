using Scripts.QuestSystem.Journal;
using Scripts.QuestSystem.UI.ActiveQuest;
using Scripts.QuestSystem.UI.QuestList;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem.UI.QuestJournal
{
    public class QuestJournalUI : MonoBehaviour, IQuestJournalUI
    {
        [SerializeField] private KeyCode QuestJournalUIButton;

        [SerializeField] private GameObject RootComponent;
        [SerializeField] private QuestListSpawner _questListSpawner;
        [SerializeField] private DisplayInfoByActiveQuest _displayInfoByActiveQuest;

        private bool _isShow;
        private IQuestJournal _questJournal;

        [Inject]
        private void Construct(IQuestJournal questJournal)
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

            _displayInfoByActiveQuest.ShowActiveQuest();

            _questListSpawner.Show();
        }

        public void Hide()
        {
            RootComponent.SetActive(false);

            _isShow = false;

            _questListSpawner.Hide();
        }
    }
}
