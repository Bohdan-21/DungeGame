using Scripts.Infrastructure.Audio;
using Scripts.Services.InputService;
using Scripts.Services.InteruptService;
using Scripts.StaticData.PlayerStaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerMove : MonoBehaviour, IInteruptHandler
    {
        public CharacterController CharacterController;
        public PlayerAnimator PlayerAnimator;
        private Camera _camera;

        private IInputService _inputService;
        private IInteruptService _interuptService;

        private float _walkSpeed;
        private bool _isInterupt;

        [Inject]
        private void Construct(IInputService inputService, PlayerCharacterConfig config, 
            IInteruptService interuptService)
        {
            _inputService = inputService;
            _interuptService = interuptService;

            _walkSpeed = config.WalkSpeed;
        }

        private void Start()
        {
            _camera = Camera.main;
            _isInterupt = false;

            _interuptService.AddInteruptHandler(this);
        }

        private void OnDestroy()
        {
            _interuptService.RemoveInteruptHandler(this);
        }


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