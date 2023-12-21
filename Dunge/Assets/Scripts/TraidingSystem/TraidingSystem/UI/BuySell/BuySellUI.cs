using Scripts.SaveData.Storage;
using System;
using UnityEngine;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.Logic;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.BuySell
{
    public class BuySellUI : MonoBehaviour
    {
        [SerializeField] private StaticTextData _staticData;
        [SerializeField] private CountSelector _countSelector;
        [SerializeField] private DynamicTextData _dynamicData;
        [SerializeField] private TradeCommandCreator _commandCreator;

        private ITradingHandler _buyerHandler;
        private ITradingHandler _salesmanHandler;
        private MerchantType _merchantType;
        private ItemType _itemType;

        public event Action<TradeCommand> SendTradeComandEvent;

        private void Start()
        {
            _countSelector.ChangeCountSelectedEvent += ChangeCountSelector;
            _commandCreator.CreateTradeCommandEvent += SendTradeComand;

            Hide();
        }

        private void OnDestroy()
        {
            _countSelector.ChangeCountSelectedEvent -= ChangeCountSelector;
            _commandCreator.CreateTradeCommandEvent -= SendTradeComand;
        }

        public void Show(MerchantType merchantType, ItemType itemType, ITradingHandler buyer, ITradingHandler salesman)
        {
            gameObject.SetActive(true);

            CacheData(buyer, salesman, merchantType, itemType);

            ShowStaticData();
            ShowDynamicData();
            ConfigurateCountSelector();
            ConfigurateTradeCommandCreator();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }


        private void CacheData(ITradingHandler buyer, ITradingHandler salesman, MerchantType merchantType, ItemType itemType)
        {
            _salesmanHandler = salesman;
            _buyerHandler = buyer;
            _merchantType = merchantType;
            _itemType = itemType;
        }

        private void ShowStaticData() => 
            _staticData.Show(_merchantType, _itemType, _buyerHandler.GetBalance().GetCurrentBalance(), 
                                                       _salesmanHandler.GetBalance().GetCurrentBalance());

        private void ShowDynamicData()
        {
            _dynamicData.Show(_countSelector.CurrentCountSelected, _itemType, _merchantType);
        }

        private void ConfigurateCountSelector()
        {
            ItemCount item;

            if (_merchantType == MerchantType.Buyer)
                item = _buyerHandler.GetStorage().GetItem(_itemType);
            else
                item = _salesmanHandler.GetStorage().GetItem(_itemType);

            _countSelector.ConfigurateCountSelector(0, item.GetItemCount());
        }

        private void ConfigurateTradeCommandCreator()
        {
            int currentMoney;

            if (_merchantType == MerchantType.Buyer)
                currentMoney = _salesmanHandler.GetBalance().GetCurrentBalance();
            else
                currentMoney = _buyerHandler.GetBalance().GetCurrentBalance();

            _commandCreator.ConfigurateCreator(_itemType, _countSelector.CurrentCountSelected, _merchantType, currentMoney);
        }


        private void ChangeCountSelector()
        {
            ShowDynamicData();
            ConfigurateTradeCommandCreator();
        }

        private void SendTradeComand(TradeCommand command) => 
            SendTradeComandEvent?.Invoke(command);
    }
}