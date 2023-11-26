using UnityEngine;
using Zenject;
using Scripts.NPC;
using Scripts.GameSystem.DialogSystem.DialogHandler;
using Scripts.GameSystem.QuestSystem.Channel;

namespace Scripts.DialogSystem.DialogHandler
{
    public class SendAlertNPCSpeak : MonoBehaviour
    {
        [SerializeField] private DialogQueueHandler _dialogQueueHandler;
        [SerializeField] private NPCType _npcType;
        
        private DialogChannel _dialogChannel;

        [Inject]
        private void Construct(DialogChannel dialogChannel) => 
            _dialogChannel = dialogChannel;

        private void Start() => 
            _dialogQueueHandler.SpeakEvent += SpeakEvent;

        private void OnDestroy() => 
            _dialogQueueHandler.SpeakEvent -= SpeakEvent;

        private void SpeakEvent() => 
            _dialogChannel.InvokeSpeakEvent(_npcType);
    }
}
