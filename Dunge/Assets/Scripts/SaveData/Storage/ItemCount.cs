using System;
using UnityEngine;

namespace Scripts.SaveData.Storage
{
    [Serializable]
    public class ItemCount
    {
        [SerializeField] private ItemType _itemType;
        [SerializeField] private int _count;

        public ItemCount(ItemType itemType, int count)
        {
            _itemType = itemType;
            _count = count;
        }

        /// <summary>
        /// For Save/Load System
        /// </summary>
        /// <param name="itemCount"></param>
        public ItemCount(ItemCount itemCount)
        {
            _itemType = itemCount._itemType;
            _count = itemCount._count;
        }

        public ItemType GetItemType() =>
            _itemType;

        public int GetItemCount() =>
            _count;

        public bool IsEqual(ItemType itemType) =>
            _itemType == itemType;

        public bool IsEnough(int count) =>
            _count >= count;

        public void Add(int count) =>
            _count += count;

        public void Reset(int count) =>
            _count = count;

        public void Take(int count) =>
            _count -= count;
    }
}