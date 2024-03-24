using Scripts.GameSystem.StatsSystem.Handler;
using Scripts.GameSystem.StatsSystem.Type;
using Scripts.Logic;
using Scripts.SaveData.PlayerData;
using Scripts.Services.AudioService.SoundService;
using Scripts.Services.PlayerProgressService;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerHealth : MonoBehaviour, IPlayerProgressLoader, IHealth
    {
        [SerializeField] private PlayerAnimator PlayerAnimator;
        [SerializeField] private PlayerStatsHandler _statsHandler;

        private ISoundsGameActionPlayer _soundPlayer;

        public event Action HealthChanged;
        public event Action UpdateHealth;

        public int CurrentHP { get; private set; }
        public int MaxHP { get; private set; }

        private float _boostForHealing;
        private float _chanceToBlockDamage;
        private float _chanceToEvasion;


        [Inject]
        private void Construct(IPlayerProgressService progressService, ISoundsGameActionPlayer soundPlayer)
        {
            progressService.AddProgressUpdater(this);
            _soundPlayer = soundPlayer;
        }


        private void Start()
        {
            _statsHandler.UpdateStatsEvent += UpdateStats;
            UpdateStats();
        }

        private void OnDestroy()
        {
            _statsHandler.UpdateStatsEvent -= UpdateStats;            
        }


        private void UpdateStats()
        {
            MaxHP = (int)_statsHandler.GetStatDataByType(TypeStat.HealthPoint).GetCurrentValue();
            _boostForHealing = _statsHandler.GetStatDataByType(TypeStat.Healing).GetCurrentValue();
            _chanceToEvasion = _statsHandler.GetStatDataByType(TypeStat.Evasion).GetCurrentValue();
            _chanceToBlockDamage = _statsHandler.GetStatDataByType(TypeStat.BlockDamage).GetCurrentValue();
        }



        public void Heal(int healthPoint)
        {
            if (CurrentHP < 1)
                return;

            int pointForHealing = healthPoint + (int)(healthPoint / (float)100 * _boostForHealing);

            if (pointForHealing + CurrentHP >= MaxHP)
                CurrentHP = MaxHP;
            else
                CurrentHP += pointForHealing;

            UpdateHealth?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            if (CurrentHP < 1)
                return;

            if (CanAvoidedDamage())
                return;

            CurrentHP -= damage;
            PlayerAnimator.PlayHit();

            PlaySound();

            HealthChanged?.Invoke();
            UpdateHealth?.Invoke();
        }

        private void PlaySound() =>
            _soundPlayer.PlayHitPlayerSound();

        private bool CanAvoidedDamage()
        {
            if (CanAvoidedDamage(_chanceToBlockDamage))
            {
                Debug.Log("BlockDamage");
                return true;
            }
            else if (CanAvoidedDamage(_chanceToEvasion))
            {
                Debug.Log("Evasion");
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


        public void LoadProgress(PlayerProgress playerProgress)
        {
            CurrentHP = playerProgress.State.CurrentHP;
            MaxHP = playerProgress.State.MaxHP;

            UpdateHealth?.Invoke();
        }

        public void UpdateProgress(PlayerProgress playerProgress)
        {
            playerProgress.State.CurrentHP = CurrentHP;
            playerProgress.State.MaxHP = MaxHP;
        }

    }
}