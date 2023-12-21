using Scripts.SaveData.Storage;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Logic
{
    public struct TradeCommand
    {
        public ItemType ItemType;
        public int Count;
        public int TotalPrice;
        public TypeTradeOperation TypeTradeOperation;

        public TradeCommand(ItemType itemType, int count, int totalPrice, TypeTradeOperation typeTradeOperation)
        {
            ItemType = itemType;
            Count = count;
            TotalPrice = totalPrice;
            TypeTradeOperation = typeTradeOperation;
        }
    }
}