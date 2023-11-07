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
        public QuestState questState;

        public List<Requirement> requirements;
        public List<Reward> rewards;
    }
}
