using Scripts.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Level
{
    public class LevelSettings : MonoBehaviour
    {
        public Transform PlayerSpawnPoint;

        public List<EnemySpawnPoint> EnemySpawnPoints;
    }
}