using System;
using System.Collections.Generic;

namespace Scripts.SaveData.Stats
{
    //TODO:возможно понадобится очистка данных
    [Serializable]
    public class StatsContainer
    {
        public List<StatData> Stats;

        public StatsContainer()
        {
            Stats = new List<StatData>();
        }

        public StatsContainer(StatsContainer playerStatsContainer) : this()
        {
            foreach (StatData statData in playerStatsContainer.Stats)
                Stats.Add(new StatData(statData));
        }
    }
}
