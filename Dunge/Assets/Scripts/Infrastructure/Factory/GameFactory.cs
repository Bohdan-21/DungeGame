using Scripts.Enemy;
using Scripts.Level;
using Scripts.Player;
using Scripts.StaticData.EnemyStaticData;
using Scripts.StaticData.GameStaticData;
using Scripts.StaticData.ProjectGlobalSettings;
using Scripts.UI.DeathUI;
using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _diContainer;
        private readonly EnemyStaticData _enemyStaticData;
        private readonly GameStaticData _gameStaticData;
        private readonly LevelSettings _levelSettings;

        public GameFactory(DiContainer diContainer, EnemyStaticData enemyStaticData,
            GameStaticData gameStaticData, LevelSettings levelSettings)
        {
            _diContainer = diContainer;
            _enemyStaticData = enemyStaticData;
            _gameStaticData = gameStaticData;
            _levelSettings = levelSettings;
        }

        public void CreateLevel()
        {
            CreatePlayer();
            CreateGameCamera();
            CreateUI();
            CreateMonster();
        }

        private void CreatePlayer() =>
            _diContainer.Bind<PlayerBehaviour>().FromComponentInNewPrefab(_gameStaticData.PlayerPrefab).AsSingle();

        private void CreateGameCamera() =>
            Instantiate(_gameStaticData.GameCamera);

        private void CreateUI()
        {
            Instantiate(_gameStaticData.GUI);

            Instantiate(_gameStaticData.DeathUI);

            Instantiate(_gameStaticData.GamePause);
        }

        private void CreateMonster()
        {
            foreach (EnemySpawnPoint enemySpawnPoint in _levelSettings.EnemySpawnPoints)
                CreateMonster(enemySpawnPoint.transform.position);
        }

        private void CreateMonster(Vector3 at)
        {
            GameObject monster = Instantiate(_enemyStaticData.EnemyPrefab);

            monster.transform.position = at;

            monster.GetComponent<NavMeshAgent>().SetDestination(at);
        }

        public void CreateDeathVFX(Vector3 at)
        {
            GameObject deathVFX = Instantiate(_gameStaticData.DeathVFX);

            deathVFX.transform.position = at;
        }

        private GameObject Instantiate(GameObject prefab)
        {
            return _diContainer.InstantiatePrefab(prefab);
        }
    }
}
