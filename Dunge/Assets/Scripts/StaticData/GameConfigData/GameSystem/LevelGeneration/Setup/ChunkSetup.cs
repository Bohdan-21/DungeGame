using UnityEngine;

namespace Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration.Setup
{
    [CreateAssetMenu(fileName = "ChunkSetup", menuName = "StaticData/GameConfigData/GameSystem/LevelGeneration/Setup/ChunkSetup")]
    public class ChunkSetup : ScriptableObject
    {
        public int ChunkHeightAndWidth;
        public int MaxAvailableSpawnedChunk;
    }
}
