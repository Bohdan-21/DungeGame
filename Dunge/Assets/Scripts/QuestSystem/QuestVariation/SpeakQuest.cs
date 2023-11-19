using Scripts.Data.SaveData;
using Scripts.Extension;
using Scripts.NPC;
using Scripts.QuestSystem.Channel;
using Scripts.QuestSystem.QuestVariation.BaseQuest;
using Scripts.QuestSystem.QuestVariation.Data;
using Scripts.Services.PlayerProgressService;
using UnityEngine;
using Zenject;

namespace Scripts.QuestSystem.QuestVariation
{
    public class SpeakQuest : Quest
    {
        [SerializeField] private SpeakQuestData _speakQuestData;

        private DialogChannel _dialogChannel;
        private IPlayerProgressService _playerProgressService;

        public override string Progress => base.Progress;

        public override QuestData QuestData { get => _speakQuestData; }

        [Inject]
        private void Construct(QuestChannel questChannel, DialogChannel dialogChannel, IPlayerProgressService playerProgressService)
        {
            _questChannel = questChannel;
            _dialogChannel = dialogChannel;
            _playerProgressService = playerProgressService;
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

            Destroy(this.gameObject);
        }

        public override void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.ActiveQuestList.QuestDataList.Add(_speakQuestData);
        }
    }
}
