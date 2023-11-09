using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.QuestSystem.QuestVariation
{
    public abstract class Quest : MonoBehaviour
    {
        public int questId;
        public string nameQuest;

        public List<Requirement> requirements;
        public List<Reward> rewards;

        protected QuestChannel _questChannel;

        protected virtual void AlertForCreatedQuest() 
        {
            _questChannel.ActivateQuest(this);
        }

        public virtual void StartTrackingQuest() { }

        public virtual void StopTrackingQuest() { }

        protected virtual void RefreshQuestProgress() { }

        protected virtual void QuestComplete() { }
    }
}
