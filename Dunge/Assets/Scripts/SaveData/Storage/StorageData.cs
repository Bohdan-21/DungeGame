using System;
using System.Collections.Generic;

namespace Scripts.SaveData.Storage
{
    [Serializable]
    public class StorageData
    {
        public List<ItemCount> items;
        
        public StorageData()
        {
            if (items != null)
                ClearData();
            else
                items = new List<ItemCount>();
        }

        public StorageData(StorageData storage) : this()
        {
            foreach (ItemCount item in storage.items)
                items.Add(item);
        }

        public void ClearData() => 
            items.Clear();
    }
}