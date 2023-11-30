using Scripts.GameSystem.StatsSystem.Handler;
using Scripts.GameSystem.StatsSystem.Type;
using Scripts.Infrastructure.Audio;
using Scripts.Logic;
using Scripts.SaveData.Stats;
using Scripts.StaticData.EnemyStaticData;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private EnemyStatsHandler _enemyStatsHandler;

        private ISoundsGameActionPlayer _soundPlayer;

        public EnemyAnimator Animator;

        public event Action HealthChanged;

        public int MaxHP { get; private set; }
        public int CurrentHP { get; private set; }

        private float _chanceToBlockDamage;
        private float _chanceToEvasion;


        [Inject]
        private void Construct(EnemyStaticData config, ISoundsGameActionPlayer soundPlayer)
        {
            MaxHP = config.Health.MaxHP;
            CurrentHP = config.Health.CurrentHP;

            _soundPlayer = soundPlayer;
        }

        private void Awake() => 
            _enemyStatsHandler.UpdateStatsEvent += UpdateStats;

        private void OnDestroy() => 
            _enemyStatsHandler.UpdateStatsEvent += UpdateStats;


        private void UpdateStats()
        {
            MaxHP = CurrentHP = (int)_enemyStatsHandler.GetStatDataByType(TypeStat.HealthPoint).GetCurrentValue();
            _chanceToBlockDamage = _enemyStatsHandler.GetStatDataByType(TypeStat.BlockDamage).GetCurrentValue();
            _chanceToEvasion = _enemyStatsHandler.GetStatDataByType(TypeStat.Evasion).GetCurrentValue();
        }

        public void TakeDamage(int damage)
        {
            if (CurrentHP < 1)
                return;

            if (CanAvoidedDamage())
                return;

            CurrentHP -= damage;

            if (!(CurrentHP < 1))
                Animator.PlayHit();
            
            PlaySound();

            HealthChanged?.Invoke();
        }

        private void PlaySound() => 
            _soundPlayer.PlayHitEnemySound();

        private bool CanAvoidedDamage()
        {
            if (CanAvoidedDamage(_chanceToBlockDamage))
            {
                Debug.Log("Enemy BlockDamage");
                return true;
            }
            else if (CanAvoidedDamage(_chanceToEvasion))
            {
                Debug.Log("Enemy Evasion");
                return true;
            }
            return false;
        }

        private bool CanAvoidedDamage(float chanceToAvoidedDamage)
        {
            int chance = GetChance();

            if (chance <= chanceToAvoidedDamage)
                return true;
            return false;
        }

        private int GetChance() =>
            UnityEngine.Random.Range(0, 100);
    }
}
