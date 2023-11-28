using Scripts.GameSystem.QuestSystem.Channel;
using Scripts.GameSystem.QuestSystem.QuestVariation.Data;
using System;
using UnityEngine;

namespace Scripts.GameSystem.QuestSystem.QuestVariation.BaseQuest
{

    public abstract class Quest : MonoBehaviour
    {
        protected QuestChannel _questChannel;


        public virtual QuestData QuestData { get; }

        public virtual string Progress { get; }


        public virtual void StartTrackingQuest() =>
            throw new NotImplementedException();

        public virtual void StopTrackingQuest() =>
            throw new NotImplementedException();


        protected virtual void AlertForCreatedQuest()
        {
            _questChannel.ActivateQuest(this);
        }

        protected virtual void RefreshQuestProgress() =>
            throw new NotImplementedException();

        protected virtual void QuestComplete() =>
            throw new NotImplementedException();


        public abstract void InitializeQuestData(QuestData questData);
    }
}
