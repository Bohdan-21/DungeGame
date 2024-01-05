using Scripts.SaveData.Storage;
using System;
using UnityEngine;
using UnityEngine.UI;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.Logic;
using Scripts.TradingStaticData.PriceData;
using Scripts.GameMechanic.ItemSystem;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.BuySell
{
    public class TradeCommandCreator : MonoBehaviour
    {
        [SerializeField] private Button _buttonForCreateTradeCommand;

        [SerializeField] private PriceStaticData _priceData;

        private int _totalPrice;
        private int _currentCountSelected;
        private TypeItem _typeItem;
        private MerchantType _merchantType;

        public event Action<TradeCommand> CreateTradeCommandEvent;

        public void ConfigurateCreator(TypeItem typeItem, int currentCountSelected, MerchantType merchantType, int currentBalance)
        {
            _typeItem = typeItem;
            _currentCountSelected = currentCountSelected;
            _merchantType = merchantType;
            _totalPrice = currentCountSelected * _priceData.GetItemPrice(typeItem);

            ConfigurateButton(currentBalance);
        }

        public void ButtonClick()
        {
            TypeTradeOperation tradeOperation;

            if (_merchantType == MerchantType.Buyer)
                tradeOperation = TypeTradeOperation.SellItemOnStore;
            else
                tradeOperation = TypeTradeOperation.BuyItemFromStore;

            CreateTradeCommandEvent?.Invoke(new TradeCommand(_typeItem, _currentCountSelected, _totalPrice, tradeOperation));
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