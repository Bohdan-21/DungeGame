using Scripts.GameSystem.LevelGeneration.DataChunk;
using System;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration
{
    [Serializable]
    public class Chunk
    {
        public TypeChunkConnection TypeChunkConnection;
        public GameObject ChunkPrefab;
    }
}
