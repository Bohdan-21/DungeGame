using System;
using System.Collections.Generic;

namespace Scripts.SaveData.Stats
{
    //TODO:возможно понадобится очистка данных
    [Serializable]
    public class PlayerStatsContainer
    {
        public List<StatData> PlayerStats;

        public PlayerStatsContainer()
        {
            PlayerStats = new List<StatData>();
        }

        public PlayerStatsContainer(PlayerStatsContainer playerStatsContainer)
        {
            PlayerStats = new List<StatData>();

            foreach (StatData statData in playerStatsContainer.PlayerStats)
                PlayerStats.Add(new StatData(statData));
        }
    }
}
