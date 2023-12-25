using UnityEngine;
using TMPro;
using System;
using Scripts.SaveData.Storage;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler;
using Scripts.GameMechanic.Item;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade
{
    public class TradeDisplayerUI : MonoBehaviour
    {
        [SerializeField] private StorageDisplayerUI _storageDisplayer;
        [SerializeField] private TextMeshProUGUI _currentMoneyText;
        [SerializeField] private MerchantType _merchantType;

        private Action<MerchantType, TypeItem> _whenUserSelectCardCallback;
        private ITradingHandler _tradingHandler;

        private void Start() => 
            _storageDisplayer.SetCallback(UserSelectItem);

        public void SetCallback(Action<MerchantType, TypeItem> whenUserSelectCardCallback) => 
            _whenUserSelectCardCallback = whenUserSelectCardCallback;

        public void Show(ITradingHandler tradingHandler)
        {
            _tradingHandler = tradingHandler;

            ShowStorage();
            ShowBalance();
        }

        public void Hide() => 
            _storageDisplayer.ClearAll();

        public void Refresh()
        {
            Hide();
            ShowStorage();
            ShowBalance();
        }

        private void ShowStorage() => 
            _storageDisplayer.SpawnStorageElement(_tradingHandler.GetStorage());

        private void ShowBalance() => 
            _currentMoneyText.text = _tradingHandler.GetBalance().GetCurrentBalance().ToString();

        private void UserSelectItem(TypeItem typeItem) => 
            _whenUserSelectCardCallback.Invoke(_merchantType, typeItem);
    }
}