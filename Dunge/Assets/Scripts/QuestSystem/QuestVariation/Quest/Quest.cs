using Scripts.Data.SaveData;
using Scripts.Services.PlayerProgressService;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.QuestSystem.QuestVariation
{
    public abstract class Quest : MonoBehaviour, IPlayerProgressUpdater
    {
        public int questId;
        public string nameQuest;

        public List<Requirement> requirements;
        public List<Reward> rewards;

        protected QuestChannel _questChannel;

        public virtual string Progress { get; }

        protected virtual void AlertForCreatedQuest() 
        {
            _questChannel.ActivateQuest(this);
        }

        public virtual void StartTrackingQuest() { }

        public virtual void StopTrackingQuest() { }

        protected virtual void RefreshQuestProgress() { }

        protected virtual void QuestComplete() { }

        public virtual void LoadProgress(PlayerProgress playerProgress)
        {
            throw new System.NotImplementedException();
        }

        public virtual void UpdateProgress(PlayerProgress playerProgress)
        {
            throw new System.NotImplementedException();
        }
    }
}
