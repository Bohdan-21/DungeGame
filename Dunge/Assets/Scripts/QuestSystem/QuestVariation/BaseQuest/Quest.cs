using Scripts.Data.SaveData;
using Scripts.QuestSystem.Channel;
using Scripts.QuestSystem.QuestVariation.Data;
using Scripts.Services.PlayerProgressService;
using System;
using UnityEngine;

namespace Scripts.QuestSystem.QuestVariation.BaseQuest
{

    public abstract class Quest : MonoBehaviour, IPlayerProgressUpdater
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


        public virtual void LoadProgress(PlayerProgress playerProgress) =>
            throw new NotImplementedException();

        public virtual void UpdateProgress(PlayerProgress playerProgress) =>
            throw new NotImplementedException();
    }
}
