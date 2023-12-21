using Scripts.SaveData.Storage;
using System;
using UnityEngine;
using TMPro;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade
{
    public class ItemCard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemTypeText;
        [SerializeField] private TextMeshProUGUI _itemCountText;
        [SerializeField] private TextMeshProUGUI _itemPriceText;

        private Action<ItemType> _whenUserSelectCardCallback;
        private ItemType _itemType;

        public void Initialize(ItemCount item, int price, Action<ItemType> whenUserSelectCardCallback)
        {
            _itemType = item.GetItemType();

            _itemTypeText.text = item.GetItemType().ToString();
            _itemCountText.text = item.GetItemCount().ToString();
            _itemPriceText.text = price.ToString();

            _whenUserSelectCardCallback = whenUserSelectCardCallback;
        }

        public void ClickCard() =>
            _whenUserSelectCardCallback.Invoke(_itemType);
    }
}