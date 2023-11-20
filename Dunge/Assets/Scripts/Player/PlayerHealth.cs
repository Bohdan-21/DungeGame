using Scripts.Data.SaveData;
using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.StateMachine;
using Scripts.Logic;
using Scripts.Services.PlayerProgressService;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerHealth : MonoBehaviour, IPlayerProgressLoader, IHealth
    {
        [SerializeField] private PlayerAnimator PlayerAnimator;
        private ISoundsGameActionPlayer _soundPlayer;

        public event Action HealthChanged;
        public event Action UpdateHealth;

        public int CurrentHP { get; private set; }
        public int MaxHP { get; private set; }

        [Inject]
        private void Construct(IPlayerProgressService progressService, ISoundsGameActionPlayer soundPlayer)
        {
            progressService.AddProgressUpdater(this);
            _soundPlayer = soundPlayer;
        }

        public void Heal(int healthPoint)
        {
            if (CurrentHP < 1)
                return;

            if (healthPoint + CurrentHP >= MaxHP)
                CurrentHP = MaxHP;
            else
                CurrentHP += healthPoint;

            UpdateHealth?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            if (CurrentHP < 1)
                return;

            CurrentHP -= damage;
            PlayerAnimator.PlayHit();

            PlaySound();

            HealthChanged?.Invoke();
            UpdateHealth?.Invoke();
        }

        private void PlaySound() =>
            _soundPlayer.PlayHitPlayerSound();

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