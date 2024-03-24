using Scripts.GameMechanic.ItemSystem;
using Scripts.StaticData.GameConficData.GameSystem.Trading.Price;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.GameSystem.Trading.Price
{
    [CreateAssetMenu(fileName = "PriceData", menuName = "StaticData/GameConfigData/GameSystem/Trading/PriceData")]
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
