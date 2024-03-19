using Scripts.Enemy;
using Scripts.GameSystem.LevelGeneration.Grid;
using Scripts.GameSystem.LevelGeneration.LevelSetting;
using Scripts.NPC.Spawn;
using Scripts.Player;
using Scripts.StaticData;
using Scripts.StaticData.GameConfigData.Enemy.Config;
using Scripts.StaticData.GameConfigData.NPC;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _diContainer;
        private readonly EnemyCharacterConfig _enemyStaticData;
        private readonly GameStaticData _gameStaticData;
        private readonly LevelData _levelSettings;
        private readonly LevelGrid _levelGrid;
        private readonly NPCPrefabReference _npcStaticData;

        public GameFactory(DiContainer diContainer, EnemyCharacterConfig enemyStaticData,
            GameStaticData gameStaticData, LevelData levelSettings, NPCPrefabReference npcStaticData, LevelGrid levelGrid)
        {
            _diContainer = diContainer;
            _enemyStaticData = enemyStaticData;
            _gameStaticData = gameStaticData;
            _levelSettings = levelSettings;
            _levelGrid = levelGrid;
            _npcStaticData = npcStaticData;
        }

        public void CreateLevel()
        {
            CreatePlayer();
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
            GameObject createdEnemy;

            foreach (LevelCell levelCell in _levelGrid.LevelCells)
            {
                foreach (EnemySpawnPoint enemySpawnPoint in levelCell.chunkData.EnemySpawnPoints)
                {
                    //TODO:fix this
                    enemyPrefab = _enemyStaticData.GetEnemyPrefabByType(/*enemySpawnPoint.enemyType*/EnemyType.Barbarian);

                    if (enemyPrefab != null)
                    {
                        createdEnemy = CreateNavMeshAgent(enemySpawnPoint.transform.position, enemyPrefab);
                        
                        levelCell.chunkData.AddCreatedCharacter(createdEnemy);
                    }
                }
            }
        }

        private void CreateNPC()
        {
            foreach (LevelCell levelCell in _levelGrid.LevelCells)
            {
                foreach (NPCSpawnPoint spawnPoint in levelCell.chunkData.NPCSpawnPoints)
                {
                    GameObject spawnedObject = _npcStaticData.GetReference(spawnPoint.NPCName);

                    if (spawnedObject != null)
                        SpawnObjectAt(spawnPoint.transform.position, spawnedObject);
                }
            }
        }

        private GameObject CreateNavMeshAgent(Vector3 at, GameObject prefabForSpawn)
        {
            GameObject spawnedAgent = SpawnObjectAt(at, prefabForSpawn);

            NavMeshAgent navMeshAgent = spawnedAgent.GetComponent<NavMeshAgent>();

            if (!navMeshAgent.Warp(at))
            {
                Debug.Log("Unsuccess warp");
                navMeshAgent.SetDestination(at);
            }

            return spawnedAgent;
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
