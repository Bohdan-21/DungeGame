using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private const float StopSpeed = 0.0f;

        [SerializeField] Animator _animator;

        private readonly int Speed = Animator.StringToHash("Speed");
        private readonly int Hit = Animator.StringToHash("Hit");
        private readonly int Die = Animator.StringToHash("Die");

        private readonly List<int> Attack = new List<int>()
        {
            Animator.StringToHash("Attack_1"),
            Animator.StringToHash("Attack_2"),
            Animator.StringToHash("Attack_3"),
            Animator.StringToHash("Attack_4")
        };

        public void PlayMove(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }

        public void PlayStopMove()
        {
            _animator.SetFloat(Speed, StopSpeed);
        }

        public void PlayAttack()
        {
            _animator.SetTrigger(Attack[Random.Range(0, Attack.Count)]);
        }

        public void PlayHit()
        {
            _animator.SetTrigger(Hit);
        }

        public void PlayDie()
        {
            _animator.SetTrigger(Die);
        }
    }
}