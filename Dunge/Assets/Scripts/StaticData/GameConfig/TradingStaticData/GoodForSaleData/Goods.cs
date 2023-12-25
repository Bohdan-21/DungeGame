using Scripts.GameMechanic.Item;
using Scripts.SaveData.Storage;
using System;

namespace Scripts.StaticData.GameConfig.TradingStaticData.GoodForSaleData
{
    [Serializable]
    public class Goods
    {
        public TypeItem TypeItem;
        public int MaxCount;
    }
}
