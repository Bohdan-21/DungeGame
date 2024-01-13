using Scripts.Enemy;
using System;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.Enemy.Config
{
    [Serializable]
    public class EnemyPrefab
    {
        public EnemyType enemyType;
        public GameObject enemyPrefabReference;
    }
}