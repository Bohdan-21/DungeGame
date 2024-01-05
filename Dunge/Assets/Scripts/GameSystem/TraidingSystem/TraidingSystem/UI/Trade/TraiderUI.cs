using Scripts.GameMechanic.ItemSystem;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.Logic;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.BuySell;
using Scripts.SaveData.Storage;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade
{
    public class TraiderUI : MonoBehaviour, ITraiderUI
    {
        public static TraiderUI Instance { get; private set; }

        [SerializeField] private TradeDisplayerUI _buyerDisplayer;
        [SerializeField] private TradeDisplayerUI _salesmanDisplayer;
        [SerializeField] private BuySellUI _buySellUI;

        public ITradingHandler _buyerHandler;
        public ITradingHandler _salesmanHandler;


        private void Awake() =>
            Instance = this;

        private void Start()
        {
            _buySellUI.SendTradeComandEvent += SendTradeCommand;

            _buyerDisplayer.SetCallback(UserSelectItem);
            _salesmanDisplayer.SetCallback(UserSelectItem);

            Hide();
        }

        private void OnDestroy() =>
            _buySellUI.SendTradeComandEvent -= SendTradeCommand;


        private void UserSelectItem(MerchantType storageType, TypeItem typeItem)
        {
            _buySellUI.Show(storageType, typeItem, _buyerHandler, _salesmanHandler);
        }

        private void SendTradeCommand(TradeCommand tradeCommand)
        {
            TradingOperation.Instance.TradeOperation(tradeCommand, _buyerHandler, _salesmanHandler);

            Refresh();
        }


        public void Show(ITradingHandler buyer, ITradingHandler salesman)
        {
            gameObject.SetActive(true);

            _buyerHandler = buyer;
            _salesmanHandler = salesman;

            _buyerDisplayer.Show(buyer);
            _salesmanDisplayer.Show(salesman);
        }

        public void Hide()
        {
            gameObject.SetActive(false);

            _buyerDisplayer.Hide();
            _salesmanDisplayer.Hide();

            _buySellUI.Hide();
        }

        private void Refresh()
        {
            _buySellUI.Hide();
            _buyerDisplayer.Refresh();
            _salesmanDisplayer.Refresh();
        }
    }
}