using Scripts.Data.SaveData;
using Scripts.Extension;
using Scripts.GameSystem.QuestSystem.Channel;
using Scripts.GameSystem.QuestSystem.QuestVariation.BaseQuest;
using Scripts.GameSystem.QuestSystem.QuestVariation.Data;
using Scripts.NPC;
using Scripts.Services.PlayerProgressService;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.QuestSystem.QuestVariation
{
    public class SpeakQuest : Quest
    {
        [SerializeField] private SpeakQuestData _speakQuestData;

        private DialogChannel _dialogChannel;
        private IPlayerProgressService _playerProgressService;

        public override string Progress => base.Progress;

        public override QuestData QuestData { get => _speakQuestData; }

        [Inject]
        private void Construct(QuestChannel questChannel, DialogChannel dialogChannel)
        {
            _questChannel = questChannel;
            _dialogChannel = dialogChannel;
        }

        private void Start() =>
            AlertForCreatedQuest();

        public override void StartTrackingQuest() =>
            _dialogChannel.SpeakEvent += TrackingSpeakEvent;

        public override void StopTrackingQuest() =>
            _dialogChannel.SpeakEvent -= TrackingSpeakEvent;


        private void TrackingSpeakEvent(NPCType npcType)
        {
            if (npcType == _speakQuestData.NPCTypeForSpeak)
                QuestComplete();
        }

        protected override void QuestComplete()
        {
            _questChannel.CompleteQuest(this);

            StopTrackingQuest();

            Destroy(gameObject);
        }

        public override void InitializeQuestData(QuestData questData)
        {
            if (questData is SpeakQuestData speakData)
                _speakQuestData = speakData;
        }
    }
}
