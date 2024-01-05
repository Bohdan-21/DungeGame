using Scripts.GameSystem.TraidingSystem.BalanceSubsystem;
using Scripts.SaveData.StorageData;
using Scripts.StaticData.GameConfig.TradingStaticData.GoodForSaleData;
using System;
using System.Collections;
using UnityEngine;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler
{
    public class Store : MonoBehaviour, ITradingHandler
    {
        [SerializeField] private Storage _storage;
        [SerializeField] private Balance _balance;

        [SerializeField] private AvailableGoodsForStoreStaticData _availableGoods;

        [SerializeField] private float _delayTimeForUpdateGoods;
        [SerializeField] private float _leftTime = 0;
        [SerializeField] private float _timeForWait = 1;

        [SerializeField] private int _maxMoneyInStoreBalance = 300;

        private void Start()
        {
            StartCoroutine(UpdateStore());
        }

        private IEnumerator UpdateStore()
        {
            while (true)
            {
                if (_leftTime <= 0)
                {
                    UpdateGoods();
                    UpdateBalance();
                    _leftTime = _delayTimeForUpdateGoods;
                }
                else
                    _leftTime -= _timeForWait;

                yield return new WaitForSeconds(_timeForWait);
            }
        }

        private void UpdateGoods()
        {
            int countGood;

            foreach (Goods availableGood in _availableGoods)
            {
                countGood = UnityEngine.Random.Range(0, availableGood.MaxCount);

                if(countGood != 0)
                    _storage.ResetItemCount(availableGood.TypeItem, countGood);
            }
        }

        private void UpdateBalance()
        {
            int money = UnityEngine.Random.Range(0, _maxMoneyInStoreBalance);

            _balance.Reset();
            _balance.Reimburse(money);
        }
        
        public Storage GetStorage() =>
            _storage;

        public Balance GetBalance() =>
            _balance;
    }
}