using Scripts.Data.SaveData;
using Scripts.Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.EnemyStaticData
{
    [CreateAssetMenu(fileName = "EmemyStaticData", menuName = "StaticData/EnemyStaticData")]
    public class EnemyStaticData : ScriptableObject
    {
        [SerializeField] private List<EnemyPrefab> enemyPrefabs;

        public AtackData AtackData;

        public State Health;

        public GameObject GetEnemyPrefabByType(EnemyType enemyType)
        {
            foreach (EnemyPrefab enemyPrefab in enemyPrefabs)
                if (enemyPrefab.enemyType == enemyType)
                    return enemyPrefab.enemyPrefabReference;
            return null;
        }
    }
}