using Scripts.Enemy;
using Scripts.GameSystem.LevelGeneration.DataChunk;
using Scripts.GameSystem.LevelGeneration.Grid;
using Scripts.NPC.Spawn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.LevelSetting
{
    public class LevelData : MonoBehaviour
    {
        public Transform PlayerSpawnPoint;

        public List<ChunkData> PreparedChunks;
    }
}