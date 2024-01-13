using Scripts.GameSystem.DialogSystem.Logic;
using Scripts.Logic;
using Scripts.Services.InputService;
using Scripts.StaticData.SystemConfigData.ControlButton;
using Scripts.UI.Interaction;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.DialogSystem.DialogHandler
{
    class DialogInteraction : MonoBehaviour
    {
        private const string NPCLayerName = "NPC";

        private KeyCode InteractionButton;

        [SerializeField] private TriggerObserver _observer;
        private DialogQueueHandler _dialogQueueHandler = null;

        private IDialogInitializer _dialogController;
        private IInteractionPanel _interactionPanel;
        private IInputService _inputService;

        [Inject]
        private void Construct(IDialogInitializer dialogController, IInteractionPanel interactionPanel,
            IInputService inputService, ControlButtons controlButtons)
        {
            _dialogController = dialogController;
            _interactionPanel = interactionPanel;
            _inputService = inputService;

            InteractionButton = controlButtons.PlayerControlButtons.AnotherControlButtons.InteractButton;
        }

        private void Start()
        {
            _observer.TriggerEnter += TriggerEnter;
            _observer.TriggerExit += TriggerExit;
        }

        private void OnDestroy()
        {
            _observer.TriggerEnter -= TriggerEnter;
            _observer.TriggerExit -= TriggerExit;
        }

        private void TriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(NPCLayerName))
            {
                _dialogQueueHandler = other.gameObject.GetComponent<DialogQueueHandler>();

                if(_dialogQueueHandler != null)
                    _interactionPanel.Show();
            }
        }

        private void TriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(NPCLayerName))
            {
                _dialogQueueHandler = null;

                _interactionPanel.Hide();
            }
        }

        private void Update()
        {
            if (_dialogQueueHandler != null)
            {
                if (_inputService.IsPress(InteractionButton))
                    _dialogController.StartDialog(_dialogQueueHandler.GetDefaultDialog());
            }
        }
    }
}
