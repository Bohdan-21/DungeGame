using Scripts.GameMechanic.ItemSystem;
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
            StorageTypeItem = new List<TypeItem>() { TypeItem.SMALL_HEAL, TypeItem.MIDDLE_HEAL, TypeItem.LARGE_HEAL };
            StorageCountItem = new List<int>() { 0, 0, 0 };

            Storage = new Dictionary<TypeItem, int>();

            Storage.Add(TypeItem.SMALL_HEAL, 0);
            Storage.Add(TypeItem.MIDDLE_HEAL, 0);
            Storage.Add(TypeItem.LARGE_HEAL, 0);
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