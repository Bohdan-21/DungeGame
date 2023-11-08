using Scripts.StaticData.QuestStaticData;
using Scripts.StaticData.QuestStaticData.Setup;
using Zenject;

namespace Scripts.QuestSystem
{
    public class TempInstaller : MonoInstaller
    {
        public QuestSetup questSetup;

        public override void InstallBindings()
        {
            Container.Bind<QuestJournal>().AsSingle();
            Container.Bind<QuestChannel>().AsSingle();
            Container.Bind<QuestMachine>().AsSingle();
            Container.Bind<QuestList>().FromInstance(questSetup.questList).AsSingle();
            Container.Bind<IQuestJournalUI>().FromComponentInNewPrefab(questSetup.questJournalUI).AsSingle();
        }
    }
}
