using UnityEngine;
using Scripts.GameSystem.StatsSystem.Logic;

namespace Scripts.GameSystem.StatsSystem.UI
{
    class PlayerStatsUI : MonoBehaviour
    {
        [SerializeField] private StatCardSpawner _statCardSpawner;

        private PlayerStats _playerStats;
        private bool _isShow = false;

        public GameObject RootComponent;
        public KeyCode keyCode;


        private void Start()
        {
            Hide();

            _playerStats = PlayerStats.Instance;

            PlayerStats.Instance.UpdateStatsEvent += UpdateStats;
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

        private void Hide()
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
