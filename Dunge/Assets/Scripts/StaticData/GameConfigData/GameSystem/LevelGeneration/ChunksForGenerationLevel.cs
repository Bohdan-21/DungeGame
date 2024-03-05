using Scripts.GameSystem.LevelGeneration.DataChunk;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration
{
    [CreateAssetMenu(fileName = "ChunksForGenerationLevel", menuName = "StaticData/GameConfigData/GameSystem/LevelGeneration/ChunksForGenerationLevel")]
    public class ChunksForGenerationLevel : ScriptableObject
    {
        [SerializeField] private List<Chunk> _chunksList;

        public Chunk GetChunk(TypeChunkConnection typeChunkConnection)
        {
            foreach (Chunk chunk in _chunksList)
            {
                if (typeChunkConnection == chunk.TypeChunkConnection)
                    return chunk;
            }
            return null;
        }
    }
}
