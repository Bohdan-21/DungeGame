using Scripts.NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.GameSystem.QuestSystem.Channel
{
    class DialogChannel
    {
        public event Action<NPCType> SpeakEvent;

        public void InvokeSpeakEvent(NPCType npcType) =>
            SpeakEvent?.Invoke(npcType);
    }
}
