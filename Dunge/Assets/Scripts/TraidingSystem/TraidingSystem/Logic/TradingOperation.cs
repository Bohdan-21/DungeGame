using Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler;
using Scripts.SaveData.Storage;
using Scripts.TraidingSystem.BalanceSubsystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Logic
{
    public class TradingOperation
    {
        public static TradingOperation Instance;

        public TradingOperation()
        {
            Instance = this;
        }

        public void TradeOperation(TradeCommand command, ITradingHandler buyer, ITradingHandler salesman)
        {
            if (command.TypeTradeOperation == TypeTradeOperation.BuyItemFromStore)
                Operation(command, buyer, salesman);
            else if (command.TypeTradeOperation == TypeTradeOperation.SellItemOnStore)
                Operation(command, salesman, buyer);
        }

        private void Operation(TradeCommand command, ITradingHandler buyer, ITradingHandler salesman)
        {
            RemoveItemFromSalesman(command.ItemType, command.Count, salesman.GetStorage());
            AddItemToBuyer(command.ItemType, command.Count, buyer.GetStorage());

            TakeMoneyFromBalanceBuyer(command.TotalPrice, buyer.GetBalance());
            AddMoneyToBalanceSalesman(command.TotalPrice, salesman.GetBalance());
        }

        private void AddItemToBuyer(ItemType itemType, int count, Storage storage) => 
            storage.AddItem(itemType, count);

        private void RemoveItemFromSalesman(ItemType itemType, int count, Storage storage) => 
            storage.TryTakeItem(itemType, count);

        private void TakeMoneyFromBalanceBuyer(int totalPrice, Balance balance) => 
            balance.Pay(totalPrice);

        private void AddMoneyToBalanceSalesman(int totalPrice, Balance balance) => 
            balance.Reimburse(totalPrice);
    }
}