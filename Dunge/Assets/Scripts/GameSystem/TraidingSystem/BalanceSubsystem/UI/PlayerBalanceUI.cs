using UnityEngine;
using TMPro;
using Scripts.GameSystem.TraidingSystem.BalanceSubsystem.Handler;
using Scripts.Player;
using Zenject;

namespace Scripts.GameSystem.TraidingSystem.BalanceSubsystem.UI
{
    class PlayerBalanceUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentMoneyText;
        private PlayerBalance _playerBalance;

        [Inject]
        private void Construct(PlayerBehaviour playerBehaviour)
        {
            _playerBalance = playerBehaviour.Balance;
        }

        private void Start()
        {
            _playerBalance.UpdatePlayerMoneyEvent += UpdatePlayerMoneyEvent;
            UpdatePlayerMoneyEvent();
        }

        private void OnDestroy() => 
            _playerBalance.UpdatePlayerMoneyEvent -= UpdatePlayerMoneyEvent;

        private void UpdatePlayerMoneyEvent() => 
            _currentMoneyText.text = _playerBalance.GetCurrentBalance().ToString();
    }
}
