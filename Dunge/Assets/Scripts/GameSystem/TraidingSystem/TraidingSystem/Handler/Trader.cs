using Scripts.GameSystem.TraidingSystem.BalanceSubsystem;
using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using Scripts.Logic;
using Scripts.Player;
using Scripts.SaveData.Storage;
using Scripts.Services.InputService;
using Scripts.StaticData.ControlButton;
using Scripts.UI.Interaction;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler
{
    public class Trader : MonoBehaviour, ITradingHandler
    {
        private const string NPCLayerName = "NPC";

        [SerializeField] private TriggerObserver _storeObserver;

        [SerializeField] private Inventory _inventory;
        [SerializeField] private Balance _balance;

        [SerializeField] private Store _store;

        private IInteractionPanel _interactionPanel;
        private IInputService _inputService;
        private ITraiderUI _traiderUI;

        private KeyCode _interactionButton;
        private bool _isShow = false;

        [Inject]
        private void Construct(ControlButtons controlButtons, IInputService inputService, IInteractionPanel interactionPanel,
                               ITraiderUI traiderUI)
        {
            _traiderUI = traiderUI;
            _inputService = inputService;
            _interactionPanel = interactionPanel;
            _interactionButton = controlButtons.PlayerControlButtons.AnotherControlButtons.InteractButton;
        }

        private void Start()
        {
            _storeObserver.TriggerEnter += TriggerEnter;
            _storeObserver.TriggerExit += TriggerExit;
        }

        private void OnDestroy()
        {
            _storeObserver.TriggerEnter -= TriggerEnter;
            _storeObserver.TriggerExit -= TriggerExit;
        }

        private void TriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(NPCLayerName))
            {
                _store = other.gameObject.GetComponent<Store>();

                if (_store != null)
                    _interactionPanel.Show();
            }
        }

        private void TriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(NPCLayerName))
            {
                _store = null;
                _interactionPanel.Hide();
            }
        }



        public Storage GetStorage() =>
            _inventory.GetStorage();

        public Balance GetBalance() =>
            _balance;

        private void Update()
        {
            if (_inputService.IsPress(_interactionButton) && _store != null)
            {
                _isShow = !_isShow;

                if (_isShow)
                    _traiderUI.Show(this, _store);
                else
                    _traiderUI.Hide();
            }
        }
    }
}