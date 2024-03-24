using Scripts.GameMechanic.ItemSystem;
using System;

namespace Scripts.SaveData.PlayerData.Storage
{
    [Serializable]
    public class ItemCountData
    {
        public TypeItem TypeItem;
        public int Count;

        public ItemCountData(TypeItem typeItem, int count)
        {
            TypeItem = typeItem;
            Count = count;
        }
    }
}