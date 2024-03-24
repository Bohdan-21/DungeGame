using System;

namespace Scripts.SaveData.PlayerData
{
    [Serializable]
    public class LevelData
    {
        public int CurrentDungeLevel;
        public int MaxReachedDungeLevel;

        public LevelData() : this(0, 0) { }

        public LevelData(int currentDungeLevel, int maxReachedDungeLevel)
        {
            CurrentDungeLevel = currentDungeLevel;
            MaxReachedDungeLevel = maxReachedDungeLevel;
        }
    }
}