using Scripts.GameMechanic.ItemSystem;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.HealingStaticData
{
    [CreateAssetMenu(fileName = "HealingData", menuName = "StaticData/HealingData")]
    class HealingStaticData : ScriptableObject
    {
        [SerializeField] private List<ItemData> itemsData;

        public int GetCountHealingPoints(TypeItem typeItem)
        {
            foreach (ItemData itemData in itemsData)
                if (itemData.TypeItem == typeItem)
                    return itemData.HealingPoint;
            return 0;
        }
    }
}
