using Scripts.GameMechanic.ItemSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.SaveData.StorageData
{
    [Serializable]
    public class Storage
    {
        [SerializeField] private List<ItemCount> items = new List<ItemCount>();

        /// <summary>
        /// For Save/Load System
        /// </summary>
        /// <param name="storage"></param>

        public Storage()
        {
            if (items != null)
                ClearData();
            else
                items = new List<ItemCount>();
        }

        public Storage(Storage storage) : this()
        {
            foreach (ItemCount item in storage.items)
                items.Add(new ItemCount(item));
        }

        public IEnumerator GetEnumerator()
        {
            foreach (ItemCount item in items)
                yield return item;
        }

        public ItemCount GetItem(TypeItem itemType) =>
            Contains(itemType);

        public void AddItem(TypeItem itemType, int count)
        {
            ItemCount item = Contains(itemType);

            if (item != null)
                AddCountToItem(item, count);
            else
                CreateItem(itemType, count);
        }
        
        public void ResetItemCount(TypeItem itemType, int count)
        {
            ItemCount item = Contains(itemType);

            if (item != null)
                ResetItemCount(item, count);
            else
                CreateItem(itemType, count);
        }

        public bool TryTakeItem(TypeItem itemType, int count)
        {
            ItemCount item = Contains(itemType);

            if (item == null)
                return false;
            else if (CanTakeItem(item, count))
            {
                TakeItem(item, count);
                return true;
            }
            else
                return false;
        }

        private ItemCount Contains(TypeItem itemType)
        {
            foreach (ItemCount item in items)
                if (item.IsEqual(itemType))
                    return item;
            return null;
        }

        private void CreateItem(TypeItem itemType, int count) =>
            items.Add(new ItemCount(itemType, count));

        private void AddCountToItem(ItemCount item, int count) =>
            item.Add(count);

        private void ResetItemCount(ItemCount item, int count) =>
            item.Reset(count);

        private bool CanTakeItem(ItemCount item, int count) =>
            item.IsEnough(count);

        private void TakeItem(ItemCount item, int count)
        {
            item.Take(count);

            if (item.GetItemCount() == 0)
                items.Remove(item);
        }

        public void ClearData() => 
            items.Clear();
    }
}