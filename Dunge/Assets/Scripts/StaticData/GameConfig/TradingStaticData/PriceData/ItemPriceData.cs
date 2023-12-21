using Scripts.SaveData.Storage;
using System;

namespace Scripts.TradingStaticData.PriceData
{
    [Serializable]
    public class ItemPriceData
    {
        public ItemType ItemType;
        public int Price;
    }
}
