using Scripts.QuestSystem.Channel;
using Scripts.QuestSystem.UI;
using Scripts.StaticData.QuestStaticData;
using Scripts.StaticData.QuestStaticData.Setup;
using System;
using Zenject;

namespace Scripts.QuestSystem
{
    public class TempInstaller : MonoInstaller
    {
        public QuestSetup questSetup;

        public override void InstallBindings()
        {
            BindQuestSystem();
            BindChannelForQuestSystem();
        }

        private void BindQuestSystem()
        {
            Container.Bind<QuestJournal>().AsSingle();
            Container.Bind<QuestMachine>().AsSingle();
            Container.Bind<QuestList>().FromInstance(questSetup.questList).AsSingle();
            Container.Bind<IQuestJournalUI>().FromComponentInNewPrefab(questSetup.questJournalUI).AsSingle();
        }

        private void BindChannelForQuestSystem()
        {
            Container.Bind<QuestChannel>().AsSingle();
            Container.Bind<CombatChannel>().AsSingle();
        }
    }
}
