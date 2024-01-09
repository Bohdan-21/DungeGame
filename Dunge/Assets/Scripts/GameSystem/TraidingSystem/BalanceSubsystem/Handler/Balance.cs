using Scripts.SaveData.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.GameSystem.TraidingSystem.BalanceSubsystem.Handler
{
    public class Balance : MonoBehaviour
    {
        [SerializeField] protected MoneyData _moneyData;

        public virtual void Reimburse(int money) =>
            _moneyData.currentMoney += money;

        public virtual void Pay(int money) =>
            _moneyData.currentMoney -= money;

        public bool CanPay(int money) =>
            _moneyData.currentMoney >= money;

        public int GetCurrentBalance() =>
            _moneyData.currentMoney;

        public void Reset() =>
            _moneyData.currentMoney = 0;
    }
}
