using Scripts.GameSystem.StatsSystem.Handler;
using Scripts.GameSystem.StatsSystem.Type;
using Scripts.Services.InputBlockerService;
using Scripts.Services.InputService;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerMove : MonoBehaviour, IInputBlockerHandler
    {
        public CharacterController CharacterController;
        public PlayerAnimator PlayerAnimator;
        [SerializeField] private PlayerStatsHandler _statsHandler;

        private Camera _gameCamera;

        private IInputService _inputService;
        private IInputBlockerService _inputBlockerService;
        
        private float _walkSpeed;
        private bool _isInputBlock;

        [Inject]
        private void Construct(IInputService inputService, ICameraFollow cameraFollow,
                               IInputBlockerService inputBlockerService)
        {
            _inputService = inputService;
            _inputBlockerService = inputBlockerService;

            _gameCamera = cameraFollow.GameCamera;
        }

        private void Start()
        {
            _isInputBlock =  false;

            _inputBlockerService.AddHandler(this);
            _statsHandler.UpdateStatsEvent += UpdateStats;

            UpdateStats();
        }

        private void OnDestroy()
        {
            _inputBlockerService.RemoveHandler(this);

            _statsHandler.UpdateStatsEvent -= UpdateStats;
        }

        private void UpdateStats() => 
            _walkSpeed = _statsHandler.GetStatDataByType(TypeStat.Speed).GetCurrentValue();

        private void Update()
        {
            Vector3 movement = Vector3.zero;

            if (!PlayerAnimator.IsDie && !PlayerAnimator.isPlay && !_isInputBlock)
            {

                if (_inputService.Movement().sqrMagnitude > Constants.Epsilon)
                {
                    movement = _gameCamera.transform.TransformDirection(_inputService.Movement());
                    movement.y = 0;
                    movement.Normalize();

                    transform.forward = movement;
                }
                movement.y = Physics.gravity.y;

                CharacterController.Move(movement * _walkSpeed * Time.deltaTime);
            }
        }

        public void BlockInput()
        {
            _isInputBlock = true;
        }

        public void UnBlockInput()
        {
            _isInputBlock = false;
        }
    }
}