using Scripts.GameSystem.LevelGeneration.DataChunk;
using System;

namespace Scripts.GameSystem.LevelGeneration.Level
{
    [Serializable]
    public class LevelCell
    {
        public int Row;
        public int Column;

        public ChunkData LevelPrefabData;

        public LevelCell(int row, int column, ChunkData levelPrefabData)
        {
            Row = row;
            Column = column;
            LevelPrefabData = levelPrefabData;
        }
    }

}
