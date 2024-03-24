using Scripts.GameMechanic.ItemSystem;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Logic
{
    public struct TradeCommand
    {
        public TypeItem typeItem;
        public int Count;
        public int TotalPrice;
        public TypeTradeOperation TypeTradeOperation;

        public TradeCommand(TypeItem typeItem, int count, int totalPrice, TypeTradeOperation typeTradeOperation)
        {
            this.typeItem = typeItem;
            Count = count;
            TotalPrice = totalPrice;
            TypeTradeOperation = typeTradeOperation;
        }
    }
}