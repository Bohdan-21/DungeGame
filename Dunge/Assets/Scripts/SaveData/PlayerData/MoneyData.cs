using System;
using UnityEngine;

namespace Scripts.SaveData.PlayerData.Money
{
    [Serializable]
    public class MoneyData
    {
        public int currentMoney;

        public MoneyData() =>
            currentMoney = 0;

        public MoneyData(MoneyData moneyData) =>
            currentMoney = moneyData.currentMoney;
    }
}
