using Scripts.GameSystem.StatsSystem.Handler;
using Scripts.GameSystem.StatsSystem.Type;
using Scripts.Services.InputService;
using Scripts.Services.InteruptService;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerMove : MonoBehaviour, IInteruptHandler
    {
        public CharacterController CharacterController;
        public PlayerAnimator PlayerAnimator;
        [SerializeField] private PlayerStatsHandler _statsHandler;

        private Camera _camera;

        private IInputService _inputService;
        private IInteruptService _interuptService;

        private float _walkSpeed;
        private bool _isInterupt;

        [Inject]
        private void Construct(IInputService inputService, IInteruptService interuptService)
        {
            _inputService = inputService;
            _interuptService = interuptService;
        }

        private void Start()
        {
            _camera = Camera.main;
            _isInterupt = false;

            _interuptService.AddInteruptHandler(this);
            _statsHandler.UpdateStatsEvent += UpdateStats;

            UpdateStats();
        }

        private void OnDestroy()
        {
            _interuptService.RemoveInteruptHandler(this);
            _statsHandler.UpdateStatsEvent -= UpdateStats;
        }


        private void UpdateStats() => 
            _walkSpeed = _statsHandler.GetStatDataByType(TypeStat.Speed).GetCurrentValue();


        private void Update()
        {
            Vector3 movement = Vector3.zero;

            if (!PlayerAnimator.IsDie && !PlayerAnimator.isPlay && !_isInterupt)
            {

                if (_inputService.Movement().sqrMagnitude > Constants.Epsilon)
                {
                    movement = _camera.transform.TransformDirection(_inputService.Movement());
                    movement.y = 0;
                    movement.Normalize();

                    transform.forward = movement;
                }
                movement.y = Physics.gravity.y;

                CharacterController.Move(movement * _walkSpeed * Time.deltaTime);
            }
        }

        public void Interupt() =>
            _isInterupt = true;

        public void Continue() =>
            _isInterupt = false;
    }
}