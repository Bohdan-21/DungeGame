using Scripts.GameMechanic.Item;
using System;
using UnityEngine;

namespace Scripts.SaveData.Storage
{
    [Serializable]
    public class ItemCount
    {
        [SerializeField] private ItemCountData _itemCountData;

        public ItemCount(TypeItem itemType, int count)
        {
            _itemCountData = new ItemCountData(itemType, count);
        }

        /// <summary>
        /// For Save/Load System
        /// </summary>
        /// <param name="itemCount"></param>
        public ItemCount(ItemCount itemCount)
        {
            _itemCountData.TypeItem = itemCount._itemCountData.TypeItem;
            _itemCountData.Count = itemCount._itemCountData.Count;
        }

        public TypeItem GetItemType() =>
            _itemCountData.TypeItem;

        public int GetItemCount() =>
            _itemCountData.Count;

        public bool IsEqual(TypeItem itemType) =>
            _itemCountData.TypeItem == itemType;

        public bool IsEnough(int count) =>
            _itemCountData.Count >= count;

        public void Add(int count) =>
            _itemCountData.Count += count;

        public void Reset(int count) =>
            _itemCountData.Count = count;

        public void Take(int count) =>
            _itemCountData.Count -= count;
    }
}