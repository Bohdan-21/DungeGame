using Scripts.Enemy;
using Scripts.Level;
using Scripts.NPC.Spawn;
using Scripts.Player;
using Scripts.StaticData.EnemyStaticData;
using Scripts.StaticData.GameStaticData;
using Scripts.StaticData.NPCStaticData;
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
        private readonly NPCStaticData _npcStaticData;

        public GameFactory(DiContainer diContainer, EnemyStaticData enemyStaticData,
            GameStaticData gameStaticData, LevelSettings levelSettings, NPCStaticData npcStaticData)
        {
            _diContainer = diContainer;
            _enemyStaticData = enemyStaticData;
            _gameStaticData = gameStaticData;
            _levelSettings = levelSettings;
            _npcStaticData = npcStaticData;
        }

        public void CreateLevel()
        {
            CreatePlayer();
            CreateGameCamera();
            CreateGUI();
            CreateMonster();
            CreateNPC();
        }

        public void CreateDeathVFX(Vector3 at)
        {
            GameObject deathVFX = Instantiate(_gameStaticData.DeathVFX);

            deathVFX.transform.position = at;
        }

        private void CreatePlayer() =>
            _diContainer.Bind<PlayerBehaviour>().FromComponentInNewPrefab(_gameStaticData.PlayerPrefab).AsSingle();

        private void CreateGameCamera() =>
            Instantiate(_gameStaticData.GameCamera);

        private void CreateGUI()
        {
            Instantiate(_gameStaticData.GUI);

            Instantiate(_gameStaticData.DeathUI);

            Instantiate(_gameStaticData.GamePause);

            Instantiate(_gameStaticData.SkillTreeUI);

            Instantiate(_gameStaticData.PlayerStatsUI);

            Instantiate(_gameStaticData.PlayerExperienceTrackerUI);

            Instantiate(_gameStaticData.PlayerBalanceUI);
        }

        private void CreateMonster()
        {
            GameObject enemyPrefab;

            foreach (EnemySpawnPoint enemySpawnPoint in _levelSettings.EnemySpawnPoints)
            {
                //TODO:fix this
                enemyPrefab = _enemyStaticData.GetEnemyPrefabByType(/*enemySpawnPoint.enemyType*/EnemyType.Barbarian);

                if(enemyPrefab != null)
                    CreateNavMeshAgent(enemySpawnPoint.transform.position, enemyPrefab);
            }
        }

        private void CreateNPC()
        {
            foreach(NPCSpawnPoint spawnPoint in _levelSettings.NPCSpawnPoints)
            {
                GameObject spawnedObject = _npcStaticData.GetReference(spawnPoint.NPCName);

                if (spawnedObject != null)
                    SpawnObjectAt(spawnPoint.transform.position, spawnedObject);
            }
        }

        private void CreateNavMeshAgent(Vector3 at, GameObject prefabForSpawn)
        {
            GameObject naMeshAgent = SpawnObjectAt(at, prefabForSpawn);

            naMeshAgent.GetComponent<NavMeshAgent>().SetDestination(at);
        }

        private GameObject SpawnObjectAt(Vector3 at, GameObject prefabForSpawn)
        {
            GameObject monster = Instantiate(prefabForSpawn);

            monster.gameObject.transform.position = at;
            return monster;
        }

        private GameObject Instantiate(GameObject prefabForSpawn)
        {
            return _diContainer.InstantiatePrefab(prefabForSpawn);
        }
    }
}
