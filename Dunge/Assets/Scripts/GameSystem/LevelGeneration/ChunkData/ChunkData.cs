using Scripts.Enemy;
using Scripts.NPC.Spawn;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.DataChunk
{
    public class ChunkData : MonoBehaviour
    {
        public Transform RootPoint;

        public List<ConnectionPoint> connectionPoints;

        public List<EnemySpawnPoint> EnemySpawnPoints;

        public List<NPCSpawnPoint> NPCSpawnPoints;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}   