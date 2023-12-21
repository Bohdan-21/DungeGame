using Scripts.SaveData.Storage;
using UnityEngine;
using TMPro;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using Scripts.TradingStaticData.PriceData;
using System;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.BuySell
{
    public class StaticTextData : MonoBehaviour
    {
        private const string NameSellOperation = "Sell Operation";
        private const string NameBuyOperation = "Buy Operation";

        [SerializeField] private TextMeshProUGUI _typeOperationText;
        [SerializeField] private TextMeshProUGUI _itemTypeText;
        [SerializeField] private TextMeshProUGUI _itemPriceText;
        [SerializeField] private TextMeshProUGUI _buyerMoneyText;
        [SerializeField] private TextMeshProUGUI _salesmanMoneyText;

        [SerializeField] private PriceStaticData _priceData;

        public void Show(MerchantType merchantType, ItemType itemType, int buyerMoney, int salesmanMoney)
        {
            ShowItemData(itemType);
            ShowTypeOperation(merchantType);
            ShowtBalance(buyerMoney, salesmanMoney);
        }

        private void ShowItemData(ItemType itemType)
        {
            _itemTypeText.text = itemType.ToString();
            _itemPriceText.text = _priceData.GetItemPrice(itemType).ToString();
        }

        private void ShowTypeOperation(MerchantType merchantType)
        {
            if (merchantType == MerchantType.Buyer)
                _typeOperationText.text = NameSellOperation;
            else
                _typeOperationText.text = NameBuyOperation;
        }

        private void ShowtBalance(int buyerMoney, int salesmanMoney)
        {
            _buyerMoneyText.text = buyerMoney.ToString();
            _salesmanMoneyText.text = salesmanMoney.ToString();
        }
    }
}