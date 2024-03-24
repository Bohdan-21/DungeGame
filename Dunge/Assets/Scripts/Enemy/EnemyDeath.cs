using Scripts.Infrastructure.Factory;
using Scripts.Services.AudioService.SoundService;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Scripts.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        private const int TimeDelayBeforeSpawnVFX = 1;
        private const float TimeDelayWhenVFXHideEnemyBody = 0.3f;

        public EnemyHealth Health;
        public EnemyAnimator Animator;

        public event Action EnemyDie;
        
        private IGameFactory _gameFactory;
        private ISoundsGameActionPlayer _soundPlayer;

        [Inject]
        private void Construct(IGameFactory gameFactory, ISoundsGameActionPlayer soundPlayer)
        {
            _gameFactory = gameFactory;
            _soundPlayer = soundPlayer;
        }

        private void Start()
        {
            Health.HealthChanged += HealthChanged;
        }

        private void HealthChanged()
        {
            if (Health.CurrentHP < 1)
            {
                Die();
            }
        }

        private void Die()
        {
            EnemyDie?.Invoke();

            Animator.PlayDie();
            
            StartCoroutine(DelayDestroy());
        }

        private IEnumerator DelayDestroy()
        {
            yield return new WaitForSeconds(TimeDelayBeforeSpawnVFX);

            Vector3 at = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z) - transform.forward;

            _gameFactory.CreateDeathVFX(at);

            PlaySound();

            yield return new WaitForSeconds(TimeDelayWhenVFXHideEnemyBody);

            Destroy(gameObject);
        }

        private void PlaySound() => 
            _soundPlayer.PLayEnemyDieSound();
    }
}
