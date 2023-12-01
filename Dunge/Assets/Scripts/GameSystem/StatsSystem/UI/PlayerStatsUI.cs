using UnityEngine;
using Zenject;
using Scripts.Player;
using Scripts.GameSystem.StatsSystem.Handler;

namespace Scripts.GameSystem.StatsSystem.UI
{
    class PlayerStatsUI : MonoBehaviour
    {
        [SerializeField] private StatCardSpawner _statCardSpawner;
        [SerializeField] private PlayerStatsHandler _playerStats;

        private bool _isShow = false;

        public GameObject RootComponent;
        public KeyCode keyCode;


        [Inject]
        private void Construct(PlayerBehaviour playerBehaviour)
        {
            _playerStats = playerBehaviour.Stats;
        }

        private void Start()
        {
            Hide();

            _playerStats.UpdateStatsEvent += UpdateStats;
        }

        private void OnDestroy()
        {
            _playerStats.UpdateStatsEvent -= UpdateStats;            
        }

        private void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                if (_isShow)
                    Hide();
                else
                    Show();
            }
        }

        private void Show()
        {
            _isShow = true;

            RootComponent.SetActive(_isShow);

            _statCardSpawner.SpawnCard(_playerStats);
        }

        public void Hide()
        {
            _isShow = false;

            RootComponent.SetActive(_isShow);

            _statCardSpawner.ClearAll();
        }

        private void UpdateStats()
        {
            if (_isShow)
            {
                Hide();
                Show();
            }
        }
    }
}
