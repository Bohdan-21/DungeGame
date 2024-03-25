using Scripts.Infrastructure.StateMachine;
using Scripts.Services.AudioService.SoundService;
using Scripts.Services.ControlButtonService;
using Scripts.Services.InputBlockerService;
using Scripts.Services.InputService;
using Scripts.Services.InteruptService;
using Scripts.UI.Settings;
using UnityEngine;
using Zenject;

namespace Scripts.UI.GamePause
{
    class GamePause : MonoBehaviour
    {
        public GameObject rootComponent;

        private KeyCode PauseButton;

        private GameStateMachine _gameStateMachine;
        private ISettingsUI _settingsUI;
        private IInputService _inputService;
        private IInteruptService _interuptService;
        private IInputBlockerService _inputBlockerService;
        private ISoundsButtonActionPlayer _soundsButtonActionPlayer;
        private bool _isPause;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, IInputService inputService, IInteruptService interuptService,
                               ISettingsUI settingsUI, ISoundsButtonActionPlayer soundsButtonActionPlayer, 
                               IControlButtonService contolButtons, IInputBlockerService inputBlockerService)
        {
            _gameStateMachine = gameStateMachine;
            _inputService = inputService;
            
            _interuptService = interuptService;
            _inputBlockerService = inputBlockerService;

            _settingsUI = settingsUI;
            _soundsButtonActionPlayer = soundsButtonActionPlayer;

            PauseButton = contolButtons.ControlButtons.SystemControlButtons.PauseButton;
        }

        private void Start()
        {
            rootComponent.SetActive(false);
            _isPause = false;
        }

        private void Update()
        {
            if (_inputService.IsPress(PauseButton))
            {
                if (_isPause)
                    Continue();
                else
                    Pause();
                _isPause = !_isPause;
            }                
        }

        public void ContinueGame()
        {
            _isPause = !_isPause;
            Continue();
        }

        public void SettingsGame()
        {
            _soundsButtonActionPlayer.PlayButtonPressSound();

            _settingsUI.Show();
        }

        public void QuitAndSaveGame()
        {
            _soundsButtonActionPlayer.PlayButtonPressSound();

            _interuptService.Continue();
            _inputBlockerService.UnBlockAllInput();

            _gameStateMachine.Enter<QuitState>();
        }

        private void Continue()
        {
            _soundsButtonActionPlayer.PlayButtonPressSound();

            _interuptService.Continue();
            _inputBlockerService.UnBlockAllInput();
            
            rootComponent.SetActive(false);

            _soundsButtonActionPlayer.PlayUnpauseSound();
        }

        private void Pause()
        {
            _soundsButtonActionPlayer.PlayButtonPressSound();

            _interuptService.Pause();
            _inputBlockerService.BlockAllInput();

            rootComponent.SetActive(true);

            _soundsButtonActionPlayer.PlayPauseSound();
        }
    }
}
