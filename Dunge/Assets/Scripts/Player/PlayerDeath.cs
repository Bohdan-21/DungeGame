using Scripts.Infrastructure.Audio;
using Scripts.Infrastructure.StateMachine;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    class PlayerDeath : MonoBehaviour
    {
        [SerializeField] PlayerAnimator PlayerAnimator;
        [SerializeField] PlayerHealth PlayerHealth;
        [SerializeField] PlayerAtack PlayerAtack;
        [SerializeField] PlayerMove PlayerMove;

        private ISoundsGameActionPlayer _soundPlayer;

        public event Action playerDeath;

        [Inject]
        private void Construct(ISoundsGameActionPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }

        private void Start()
        {
            PlayerHealth.HealthChanged += PlayerTakeDamage;
        }

        private void PlayerTakeDamage()
        {
            if (PlayerHealth.CurrentHP < 1)
            {
                PlayerAnimator.PlayDie();

                PlayerAtack.enabled = false;
                PlayerMove.enabled = false;
                
                PlayeSound();

                playerDeath.Invoke();
            }
        }

        private void PlayeSound() => 
            _soundPlayer.PlayPlayerLoseSound();
    }
}
