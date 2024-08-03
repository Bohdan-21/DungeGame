using System;

namespace Scripts.SaveData.PlayerData
{
    [Serializable]
    public class LevelData
    {
        public string NextLoadRoom;
        public int LevelDunge;

        public LevelData() : this("", 0) { }

        public LevelData(string nextLoadRoom, int levelDunge)
        {
            NextLoadRoom = nextLoadRoom;
            LevelDunge = levelDunge;
        }
    }
}