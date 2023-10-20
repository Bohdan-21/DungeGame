using Scripts.Data.SaveData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.EnemyStaticData
{
    [CreateAssetMenu(fileName = "EmemyStaticData", menuName = "StaticData/EnemyStaticData")]
    public class EnemyStaticData : ScriptableObject
    {
        public GameObject EnemyPrefab;

        public AtackData AtackData;

        public State Health;
    }
}