using Scripts.GameMechanic.Item;
using System;
using System.Collections.Generic;

namespace Scripts.SaveData
{
    [Serializable]
    public class Inventory//словарь нужно как то сериализовать
    {
        public Dictionary<TypeItem, int> Storage;

        public List<int> StorageCountItem;
        public List<TypeItem> StorageTypeItem;

        public Inventory()
        {
            StorageTypeItem = new List<TypeItem>() { TypeItem.SMALL, TypeItem.MIDDLE, TypeItem.LARGE };
            StorageCountItem = new List<int>() { 0, 0, 0 };

            Storage = new Dictionary<TypeItem, int>();

            Storage.Add(TypeItem.SMALL, 0);
            Storage.Add(TypeItem.MIDDLE, 0);
            Storage.Add(TypeItem.LARGE, 0);
        }

        public Inventory(Inventory inventory)
        {
            StorageTypeItem = new List<TypeItem>(inventory.StorageTypeItem);
            StorageCountItem = new List<int>(inventory.StorageCountItem);
        }

        public void Clear()
        {
            StorageTypeItem.Clear();
            StorageCountItem.Clear();
        }
    }
}