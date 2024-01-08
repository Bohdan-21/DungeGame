using Scripts.GameSystem.TraidingSystem.BalanceSubsystem;
using Scripts.Player;
using Scripts.SaveData.StorageData;
using UnityEngine;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler
{
    public class Trader : MonoBehaviour, ITradingHandler
    {
        [SerializeField] private PlayerInventory _inventory;
        [SerializeField] private Balance _balance;

        public Storage GetStorage() =>
            _inventory.GetStorage();

        public Balance GetBalance() =>
            _balance;
    }
}