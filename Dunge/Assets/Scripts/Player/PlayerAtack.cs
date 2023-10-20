using Scripts.Infrastructure.Audio;
using Scripts.Logic;
using Scripts.Services.InputService;
using Scripts.Services.InteruptService;
using Scripts.StaticData.Control;
using Scripts.StaticData.PlayerStaticData;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerAtack : MonoBehaviour, IInteruptHandler
    {
        private KeyCode AttackButton;

        public PlayerAnimator PlayerAnimator;

        private Collider[] _hits = new Collider[3];
        private IInputService _inputService;
        private IInteruptService _interuptService;
        private ISoundsGameActionPlayer _soundPlayer;

        private bool _isInterupt;
        private int _layerMask;
        private int _damage = 20;
        private float _attackRadius = 1;

        [Inject]
        private void Construct(IInputService inputService, IInteruptService interuptService, PlayerCharacterConfig config,
                               ISoundsGameActionPlayer soundPlayer, ControlButtons controlButtons)
        {
            _inputService = inputService;
            _interuptService = interuptService;
            _soundPlayer = soundPlayer;

            _damage = config.Damage;
            _attackRadius = config.AttackRadius;

            AttackButton = controlButtons.PlayerControlButtons.AttackControlButtons.AttackButton;
        }

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer("Enemy");
            
            _isInterupt = false;

            _interuptService.AddInteruptHandler(this);
        }

        private void OnDestroy()
        {
            _interuptService.RemoveInteruptHandler(this);
        }


        private void Update()
        {
            StartAttack();
        }

        private void StartAttack()
        {
            if (_inputService.IsPress(AttackButton) && !_isInterupt)
            {
                PlayerAnimator.PlayAttack();
            }
        }

        private void OnAttack()
        {
            PlaySound();

            int hitAmount = Physics.OverlapSphereNonAlloc(StartPoint(), _attackRadius, _hits, _layerMask);

            if (hitAmount > 0)
            {
                for (int i = 0; i < hitAmount; i++)
                {
                    _hits[i].transform.GetComponent<IHealth>().TakeDamage(_damage);
                }
            }
        }


        private void EndAttack()
        {

        }

        private Vector3 StartPoint()
        {
            Vector3 startPoint = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

            return startPoint + transform.forward;
        }

        private void PlaySound() => 
            _soundPlayer.PlayAttackPlayerSound();

        public void Interupt() =>
            _isInterupt = true;

        public void Continue() =>
            _isInterupt = false;
    }
}