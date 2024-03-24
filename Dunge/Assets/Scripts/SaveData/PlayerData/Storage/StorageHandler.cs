using Scripts.GameMechanic.ItemSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.SaveData.PlayerData.Storage
{
    [Serializable]
    public class StorageHandler
    {
        [SerializeField] private StorageData _storageData;

        public event Action UpdateStorageDataEvent;

        public StorageHandler()
        {
            _storageData = new StorageData();
        }

        public StorageHandler(StorageData storage)
        {
            _storageData = new StorageData(storage);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (ItemCount item in _storageData.items)
                yield return item;
        }

        public ItemCount GetItem(TypeItem itemType) =>
            Contains(itemType);

        public StorageData GetStorageData() =>
            _storageData;

        public void AddItem(TypeItem itemType, int count)
        {
            ItemCount item = Contains(itemType);

            if (item != null)
                AddCountToItem(item, count);
            else
                CreateItem(itemType, count);

            UpdateStorageDataEvent?.Invoke();
        }

        public void ResetItemCount(TypeItem itemType, int count)
        {
            ItemCount item = Contains(itemType);

            if (item != null)
                ResetItemCount(item, count);
            else
                CreateItem(itemType, count);

            UpdateStorageDataEvent?.Invoke();
        }

        public bool TryTakeItem(TypeItem itemType, int count)
        {
            ItemCount item = Contains(itemType);

            if (item == null)
                return false;
            else if (CanTakeItem(item, count))
            {
                TakeItem(item, count);
                UpdateStorageDataEvent?.Invoke();
                return true;
            }
            else
                return false;
        }

        private ItemCount Contains(TypeItem itemType)
        {
            foreach (ItemCount item in _storageData.items)
                if (item.IsEqual(itemType))
                    return item;
            return null;
        }

        private void CreateItem(TypeItem itemType, int count) =>
            _storageData.items.Add(new ItemCount(itemType, count));

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
                _storageData.items.Remove(item);
        }

        public void ClearData() =>
            _storageData.ClearData();
    }
}