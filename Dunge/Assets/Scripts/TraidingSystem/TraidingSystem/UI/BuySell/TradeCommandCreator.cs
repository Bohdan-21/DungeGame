using Scripts.SaveData.Storage;
using System;
using UnityEngine;
using UnityEngine.UI;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.Logic;
using Scripts.TradingStaticData.PriceData;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.BuySell
{
    public class TradeCommandCreator : MonoBehaviour
    {
        [SerializeField] private Button _buttonForCreateTradeCommand;

        [SerializeField] private PriceStaticData _priceData;

        private int _totalPrice;
        private int _currentCountSelected;
        private ItemType _itemType;
        private MerchantType _merchantType;

        public event Action<TradeCommand> CreateTradeCommandEvent;

        public void ConfigurateCreator(ItemType itemType, int currentCountSelected, MerchantType merchantType, int currentBalance)
        {
            _itemType = itemType;
            _currentCountSelected = currentCountSelected;
            _merchantType = merchantType;
            _totalPrice = currentCountSelected * _priceData.GetItemPrice(itemType);

            ConfigurateButton(currentBalance);
        }

        public void ButtonClick()
        {
            TypeTradeOperation tradeOperation;

            if (_merchantType == MerchantType.Buyer)
                tradeOperation = TypeTradeOperation.SellItemOnStore;
            else
                tradeOperation = TypeTradeOperation.BuyItemFromStore;

            CreateTradeCommandEvent?.Invoke(new TradeCommand(_itemType, _currentCountSelected, _totalPrice, tradeOperation));
        }

        private void ConfigurateButton(int currentBalance)
        {
            if (currentBalance >= _totalPrice && _totalPrice != 0)
                _buttonForCreateTradeCommand.interactable = true;
            else
                _buttonForCreateTradeCommand.interactable = false;
        }
    }
}