using Scripts.GameMechanic.ItemSystem;
using Scripts.StaticData.GameConfigData.Item.Item;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.GameConfigData.Item
{
    [CreateAssetMenu(fileName = "ItemCollection", menuName = "StaticData/GameConfigData/Item/ItemCollection")]
    public class ItemCollection : ScriptableObject
    {
        [SerializeField] private List<ItemData> _itemCollection;

        public ItemData GetItem(TypeItem typeItem)
        {
            foreach (ItemData item in _itemCollection)
                if (item.typeItem == typeItem)
                    return item;
            return null;
        }
    }
}
