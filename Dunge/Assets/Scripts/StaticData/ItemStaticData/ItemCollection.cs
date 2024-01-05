using Scripts.GameMechanic.ItemSystem;
using Scripts.StaticData.ItemStaticData.Item;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.StaticData.ItemStaticData
{
    [CreateAssetMenu(fileName = "ItemCollection", menuName = "StaticData/Item/ItemCollection")]
    public class ItemCollection : ScriptableObject
    {
        [SerializeField] private List<ItemData> _itemCollection;

        public ItemData GetItem(TypeItem typeItem)
        {
            foreach (Item.ItemData item in _itemCollection)
                if (item.typeItem == typeItem)
                    return item;
            return null;
        }
    }
}
