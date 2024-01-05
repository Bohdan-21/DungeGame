using Scripts.SaveData.StorageData;
using UnityEngine;
using TMPro;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using Scripts.TradingStaticData.PriceData;
using System;
using Scripts.GameMechanic.ItemSystem;

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

        public void Show(MerchantType merchantType, TypeItem typeItem, int buyerMoney, int salesmanMoney)
        {
            ShowItemData(typeItem);
            ShowTypeOperation(merchantType);
            ShowtBalance(buyerMoney, salesmanMoney);
        }

        private void ShowItemData(TypeItem typeItem)
        {
            _itemTypeText.text = typeItem.ToString();
            _itemPriceText.text = _priceData.GetItemPrice(typeItem).ToString();
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