using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using Scripts.Player;
using Scripts.SaveData.Storage;
using Scripts.TraidingSystem.BalanceSubsystem;
using UnityEngine;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler
{
    public class Trader : MonoBehaviour, ITradingHandler
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Balance _balance;

        [SerializeField] private Store _store;

        private bool _isShow = false;

        public Storage GetStorage() =>
            _inventory.GetStorage();

        public Balance GetBalance() =>
            _balance;

        //TODO: remove me
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _store = GameObject.Find("Store1").GetComponent<Store>();
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                _store = GameObject.Find("Store2").GetComponent<Store>();
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                _store = GameObject.Find("Store3").GetComponent<Store>();

            if (Input.GetKeyDown(KeyCode.L))
            {
                _isShow = !_isShow;

                if (_isShow)
                    TraiderUI.Instance.Show(this, _store);
                else
                    TraiderUI.Instance.Hide();
            }
        }


    }
}