using Scripts.Enemy;
using Scripts.NPC.Spawn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Level
{
    public class LevelSettings : MonoBehaviour
    {
        public Transform PlayerSpawnPoint;

        public List<EnemySpawnPoint> EnemySpawnPoints;

        public List<NPCSpawnPoint> NPCSpawnPoints;
    }
}