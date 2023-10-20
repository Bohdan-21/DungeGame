using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    /// <summary>
    /// Нужно добавить переменую для того чтобы отмечать проигрывается ли в конкретный момент времени
    /// анимация атаки. Это нужно сделать чтобы избавиться от спама атак.
    /// </summary>
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;

        private readonly int Speed = Animator.StringToHash("Speed");
        private readonly int Hit = Animator.StringToHash("Hit");
        private readonly int Die = Animator.StringToHash("Die");

        private readonly List<int> Attack = new List<int>()
        {
            Animator.StringToHash("Attack_1"),
            Animator.StringToHash("Attack_2"),
            Animator.StringToHash("Attack_3"),
            Animator.StringToHash("Attack_4"),
        };

        public bool isPlay = false;
        public bool IsDie { get; private set; }

        private bool _isAttacking;

        private void Start()
        {
            IsDie = false;
            _isAttacking = false;
        }

        private void Update()
        {
            _animator.SetFloat(Speed, _characterController.velocity.magnitude);
        }

        public void PlayAttack()
        {
            if (!IsDie && !isPlay && !_isAttacking)
            {
                _isAttacking = true;
                _animator.SetTrigger(Attack[Random.Range(0, Attack.Count)]);
            }
        }

        public void PlayHit()
        {
            if(!IsDie)
                _animator.SetTrigger(Hit);
        }

        public void PlayDie()
        {
            IsDie = true;
            _animator.SetTrigger(Die);
        }

        public void StartPlayAnimation() =>
            isPlay = true;

        public void StopPlayAnimation()
        {
            isPlay = false;
            _isAttacking = false;
        }
    }
}