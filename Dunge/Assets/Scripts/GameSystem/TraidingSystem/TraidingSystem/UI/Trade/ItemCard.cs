using Scripts.SaveData.StorageData;
using System;
using UnityEngine;
using TMPro;
using Scripts.GameMechanic.ItemSystem;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade
{
    public class ItemCard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemTypeText;
        [SerializeField] private TextMeshProUGUI _itemCountText;
        [SerializeField] private TextMeshProUGUI _itemPriceText;

        private Action<TypeItem> _whenUserSelectCardCallback;
        private TypeItem _itemType;

        public void Initialize(ItemCount item, int price, Action<TypeItem> whenUserSelectCardCallback)
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