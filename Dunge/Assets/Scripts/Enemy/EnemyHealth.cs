using Scripts.Infrastructure.Audio;
using Scripts.Logic;
using Scripts.StaticData.EnemyStaticData;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        private ISoundsGameActionPlayer _soundPlayer;

        public EnemyAnimator Animator;

        public event Action HealthChanged;

        public int MaxHP { get; private set; }
        public int CurrentHP { get; private set; }

        [Inject]
        private void Construct(EnemyStaticData config, ISoundsGameActionPlayer soundPlayer)
        {
            MaxHP = config.Health.MaxHP;
            CurrentHP = config.Health.CurrentHP;

            _soundPlayer = soundPlayer;
        }

        public void TakeDamage(int damage)
        {
            if (CurrentHP < 1)
                return;

            CurrentHP -= damage;

            if (!(CurrentHP < 1))
                Animator.PlayHit();
            
            PlaySound();

            HealthChanged?.Invoke();
        }

        private void PlaySound() => 
            _soundPlayer.PlayHitEnemySound();
    }
}
