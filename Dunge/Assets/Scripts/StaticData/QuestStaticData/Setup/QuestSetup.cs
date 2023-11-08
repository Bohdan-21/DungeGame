using UnityEngine;

namespace Scripts.StaticData.QuestStaticData.Setup
{
    [CreateAssetMenu(fileName = "QuestSetup", menuName = "StaticData/QuestSystem/Setup/QuestSetup")]
    public class QuestSetup : ScriptableObject
    {
        public QuestList questList;
        public GameObject questJournalUI;
    }
}
