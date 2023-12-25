using Scripts.GameMechanic.Item;
using Scripts.SaveData.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.TradingStaticData.PriceData
{
    [CreateAssetMenu(fileName = "PriceData", menuName = "StaticData/TradingStaticData/PriceData")]
    class PriceStaticData : ScriptableObject
    {
        [SerializeField] private List<ItemPriceData> pricesData;

        public int GetItemPrice(TypeItem itemType)
        {
            foreach (ItemPriceData itemData in pricesData)
                if (itemData.ItemType == itemType)
                    return itemData.Price;
            return 0;
        }
    }
}
