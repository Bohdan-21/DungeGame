using Scripts.GameSystem.LevelGeneration.DataChunk;
using System;

namespace Scripts.GameSystem.LevelGeneration.Level
{
    [Serializable]
    public class LevelCell
    {
        public int Row;
        public int Column;

        public ChunkData chunkData;

        public LevelCell(int row, int column, ChunkData prefabChunkData)
        {
            Row = row;
            Column = column;
            chunkData = prefabChunkData;
        }
    }

}
