using Scripts.Infrastructure.StateMachine;
using Scripts.Player;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.DeathUI
{
    public class DeathUI : MonoBehaviour
    {
        [SerializeField] private CanvasGroup showHideComponent;
        [SerializeField] private Button restartButton;

        private PlayerDeath _playerDeath;
        private GameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(PlayerBehaviour playerBehaviour, GameStateMachine gameStateMachine)
        {
            _playerDeath = playerBehaviour.Death;
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            Hide();

            _playerDeath.playerDeath += PlayerDeath;
        }


        private void OnDestroy()
        {
            _playerDeath.playerDeath -= PlayerDeath;
        }

        public void RestartLevel()
        {
            StopAllCoroutines();

            Hide();

            _gameStateMachine.Enter<DeathState>();
        }

        private void PlayerDeath()
        {
            Show();
        }


        private void Show()
        {
            gameObject.SetActive(true);

            restartButton.interactable = false;

            StartCoroutine(ShowDelay());
        }

        private IEnumerator ShowDelay()
        {
            while (showHideComponent.alpha < 1)
            {
                showHideComponent.alpha += 0.03f;

                yield return new WaitForSeconds(0.03f);
            }

            restartButton.interactable = true;
        }

        private void Hide()
        {
            showHideComponent.alpha = 0;

            gameObject.SetActive(false);
        }

    }
}