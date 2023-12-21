using Scripts.SaveData.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.StaticData.HealingStaticData
{
    [CreateAssetMenu(fileName = "HealingData", menuName = "StaticData/HealingData")]
    class HealingStaticData : ScriptableObject
    {
        [SerializeField] private List<ItemData> itemsData;

        public int GetCountHealingPoints(ItemType itemType)
        {
            foreach (ItemData itemData in itemsData)
                if (itemData.ItemType == itemType)
                    return itemData.HealingPoint;
            return 0;
        }
    }
}
