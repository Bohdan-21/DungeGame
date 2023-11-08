using Scripts.Enemy;
using System;
using UnityEngine;

namespace Scripts.StaticData.EnemyStaticData
{
    [Serializable]
    public class EnemyPrefab
    {
        public EnemyType enemyType;
        public GameObject enemyPrefabReference;
    }
}