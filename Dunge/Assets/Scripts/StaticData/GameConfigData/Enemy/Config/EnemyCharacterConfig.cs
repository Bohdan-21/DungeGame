using Scripts.Enemy;
using Scripts.SaveData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.Enemy.Config
{
    [CreateAssetMenu(fileName = "EnemyCharacterConfig", menuName = "StaticData/GameConfigData/Enemy/EnemyCharacterConfig")]
    //TODO:эту часть нужно переделать чтобы у каждого моба были свои индивидуальные настрой силы атаки, скорости и т.д.
    public class EnemyCharacterConfig : ScriptableObject
    {
        [SerializeField] private List<EnemyPrefab> enemyPrefabs;

        public AtackData AtackData;

        //TODO: fix this why PlayerState
        public PlayerState Health;

        public GameObject GetEnemyPrefabByType(EnemyType enemyType)
        {
            foreach (EnemyPrefab enemyPrefab in enemyPrefabs)
                if (enemyPrefab.enemyType == enemyType)
                    return enemyPrefab.enemyPrefabReference;
            return null;
        }
    }
}