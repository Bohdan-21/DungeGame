using Scripts.Enemy;
using Scripts.SaveData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.Enemy.Config
{
    [CreateAssetMenu(fileName = "EnemyCharacterConfig", menuName = "StaticData/GameConfigData/Enemy/EnemyCharacterConfig")]
    public class EnemyCharacterConfig : ScriptableObject
    {
        [SerializeField] private List<EnemyPrefab> enemyPrefabs;

        public AtackData AtackData;

        public GameObject GetEnemyPrefabByType(EnemyType enemyType)
        {
            foreach (EnemyPrefab enemyPrefab in enemyPrefabs)
                if (enemyPrefab.enemyType == enemyType)
                    return enemyPrefab.enemyPrefabReference;
            return null;
        }
    }
}