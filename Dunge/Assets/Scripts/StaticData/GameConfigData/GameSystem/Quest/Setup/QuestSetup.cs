using UnityEngine;

namespace Scripts.StaticData.GameConfigData.GameSystem.QuestStaticData.Setup
{
    [CreateAssetMenu(fileName = "QuestSetup", menuName = "StaticData/GameConfigData/GameSystem/Quest/Setup/QuestSetup")]
    public class QuestSetup : ScriptableObject
    {
        public QuestList questList;
        public GameObject questJournal;
        public GameObject questJournalUI;
        public GameObject questTrackerUI;
    }
}
