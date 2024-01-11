using Scripts.GameMechanic.ItemSystem;
using Scripts.SaveData.Storage;
using System;

namespace Scripts.TradingStaticData.PriceData
{
    [Serializable]
    public class ItemPriceData
    {
        public TypeItem ItemType;
        public int Price;
    }
}
