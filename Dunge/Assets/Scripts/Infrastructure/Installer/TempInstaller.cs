using Scripts.GameSystem.QuestSystem.Channel;
using Scripts.GameSystem.QuestSystem.Factory;
using Scripts.GameSystem.QuestSystem.Journal;
using Scripts.GameSystem.QuestSystem.UI.QuestJournal;
using Scripts.StaticData.GameConfigData.GameSystem.QuestStaticData;
using Scripts.StaticData.GameConfigData.GameSystem.QuestStaticData.Setup;
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
            Container.Bind<QuestFactory>().AsSingle();
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
