using Scripts.GameSystem.TraidingSystem.TraidingSystem.UI.Trade;
using Scripts.Logic;
using Scripts.Services.ControlButtonService;
using Scripts.Services.InputBlockerService;
using Scripts.Services.InputService;
using Scripts.UI.Interaction;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.TraidingSystem.TraidingSystem.Handler
{
    public class TradingInteraction : MonoBehaviour
    {
        private const string NPCLayerName = "NPC";

        [SerializeField] private TriggerObserver _storeObserver;

        [SerializeField] private Trader _trader;
        [SerializeField] private Store _store;

        private IInteractionPanel _interactionPanel;
        private IInputService _inputService;
        private ITraiderUI _traiderUI;
        private IInputBlockerService _inputBlockerService;

        private KeyCode _interactionButton;
        private bool _isShow = false;

        [Inject]
        private void Construct(IControlButtonService controlButtons, IInputService inputService, IInteractionPanel interactionPanel,
                               ITraiderUI traiderUI, IInputBlockerService inputBlockerService)
        {
            _traiderUI = traiderUI;
            _inputService = inputService;
            _interactionPanel = interactionPanel;
            _interactionButton = controlButtons.ControlButtons.PlayerControlButtons.AnotherControlButtons.InteractButton;

            _inputBlockerService = inputBlockerService;
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


        private void Update()
        {
            if (_inputService.IsPress(_interactionButton) && _store != null)
            {
                _isShow = !_isShow;

                if (_isShow)
                {
                    _traiderUI.Show(_trader, _store);
                    _inputBlockerService.BlockAllInput();
                }
                else
                {
                    _traiderUI.Hide();
                    _inputBlockerService.UnBlockAllInput();
                }
            }
        }
    }
}