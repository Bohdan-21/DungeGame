using System;
using UnityEngine;

namespace Scripts.TraidingSystem.BalanceSubsystem
{
    [Serializable]
    public class Balance
    {
        [SerializeField] private int _currentMoney;

        public Balance() =>
            _currentMoney = 0;

        public void Reimburse(int money) =>
            _currentMoney += money;

        public void Pay(int money) =>
            _currentMoney -= money;

        public bool CanPay(int money) =>
            _currentMoney >= money;

        public int GetCurrentBalance() =>
            _currentMoney;

        public void Reset() =>
            _currentMoney = 0;
    }
}
