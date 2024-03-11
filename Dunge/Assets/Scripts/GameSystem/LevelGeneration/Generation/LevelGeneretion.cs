using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Scripts.GameSystem.LevelGeneration.Level;
using Scripts.GameSystem.LevelGeneration.DataChunk;
using Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration;
using Scripts.GameSystem.LevelGeneration.ConnectionStrategies;
using Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration.Setup;
using Zenject;

namespace Scripts.GameSystem.LevelGeneration.Generation
{
    public class LevelGeneretion : MonoBehaviour
    {
        [SerializeField] private LevelGrid LevelGrid;
        [SerializeField] private LevelData levelData;
        [SerializeField] private ChunkSetup chunkSetup;
        
        [SerializeField] private bool needSpecialDeadEndChunk = true;

        [SerializeField] private ChunksForGenerationLevel prefabsForGenerationLevel;

        private ConnectionStrategyFactory _connectionStrategy;
        private DiContainer _diContainer;
        
        private GameObject createdChunk;

        private TypeConnectionForCell typeConnection;
        private Chunk chunk;

        private int uniqueIndex = 1;

        private List<ChunkData> currentPointForGenerateLevel = new List<ChunkData>();
        private List<GameObject> createdChunksList = new List<GameObject>();
        private List<TypeChunkConnection> typeChunkConnection;

        [Inject]
        private void Construct(ConnectionStrategyFactory connectionStrategy, DiContainer diContainer)
        {
            _connectionStrategy = connectionStrategy;
            _diContainer = diContainer;
        }

        public IEnumerator GenerateLevel()
        {
            TakeChunkDataForGenerateLevel(levelData.StartLevelPrefabData);

            yield return GenerateLevelChunks();
        }

        private void TakeChunkDataForGenerateLevel(ChunkData prefabData) =>
            currentPointForGenerateLevel.Add(prefabData);

        private IEnumerator GenerateLevelChunks()
        {
            while (true)
            {
                yield return GenerateChunks();

                if (createdChunksList.Count == 0)
                    break;

                UpdateChunkDataForGenerateLevel();
            }
        }

        private IEnumerator GenerateChunks()
        {
            foreach (ChunkData chunkData in currentPointForGenerateLevel)
            {
                foreach (ConnectionPoint connectionPoint in chunkData.connectionPoints)
                {
                    if (IsDataPreparingSuccessForSpawn(chunkData, connectionPoint))
                    {
                        InstantiateChunk();

                        SetUniqueNameForCreatedChunk();

                        try
                        {
                            PositionateCreatedChunk(chunkData, connectionPoint);

                            UpdateDataAboutCreatedChunk();
                        }
                        catch (Exception)
                        {
#if UNITY_EDITOR
                            ShowDebugInfoInConsole(chunkData, connectionPoint);
#endif
                            DestroyCreatedChunk();
                        }

                        yield return null;
                    }
                }
            }
        }

        private void UpdateChunkDataForGenerateLevel()
        {
            ChunkData levelPrefabData;

            currentPointForGenerateLevel.Clear();

            foreach (GameObject spawnedLevelPrefab in createdChunksList)
            {
                levelPrefabData = spawnedLevelPrefab.GetComponent<ChunkData>();

                currentPointForGenerateLevel.Add(levelPrefabData);
            }

            createdChunksList.Clear();
        }


        private bool IsDataPreparingSuccessForSpawn(ChunkData chunkData, ConnectionPoint connectionPoint)
        {
            if (IsPointAlreadyConnect(connectionPoint))
                return false;
            if (IsFailedDetectTypeConnectionForCell(chunkData, connectionPoint))
                return false;
            if (IsFailedDetectTypesChunkConnections())
                return false;
            if (IsFailedGetChunk())
                return false;

            return true;
        }

        private bool IsPointAlreadyConnect(ConnectionPoint connectionPoint) =>
            connectionPoint.IsPointConnect;

        private bool IsFailedDetectTypeConnectionForCell(ChunkData chunkData, ConnectionPoint connectionPoint)
        {
            typeConnection = LevelGrid.DetectTypeConnection(chunkData.RootPoint.position, connectionPoint.PointForConnect.position);

            if (typeConnection == null)
                return true;
            return false;
        }

        private bool IsFailedDetectTypesChunkConnections()
        {
            typeChunkConnection = _connectionStrategy.GetTypeChunkConnection(typeConnection);

            if (typeChunkConnection == null)
                return true;
            return false;
        }

        private bool IsFailedGetChunk()
        {
            TypeChunkConnection randomTypeChunk = typeChunkConnection[UnityEngine.Random.Range(0, typeChunkConnection.Count)];

            randomTypeChunk = IsNeedSpecialChunk(randomTypeChunk);

            chunk = prefabsForGenerationLevel.GetChunk(randomTypeChunk);

            if (chunk == null)
                return true;
            return false;
        }

        private TypeChunkConnection IsNeedSpecialChunk(TypeChunkConnection typeChunk)
        {
            if (needSpecialDeadEndChunk && typeChunk == TypeChunkConnection.DeadEndConnection)
            {
                typeChunk = TypeChunkConnection.SpecialDeadEndConnection;
                needSpecialDeadEndChunk = false;
            }
            return typeChunk;
        }


        private void InstantiateChunk()
        {
            createdChunk = _diContainer.InstantiatePrefab(chunk.ChunkPrefab);
        }

        private void DestroyCreatedChunk()
        {
            Destroy(createdChunk);
        }


        private void SetUniqueNameForCreatedChunk()
        {
            createdChunk.name = uniqueIndex.ToString();

            uniqueIndex++;
        }


        private void ShowDebugInfoInConsole(ChunkData chunkData, ConnectionPoint connectionPoint)
        {
            Vector3 direction = Calculate.CalculateDirection(chunkData.RootPoint.position, connectionPoint.PointForConnect.position);

            Debug.LogError("Object name:" + createdChunk.name);
            Debug.LogWarning("Position:" + (chunkData.RootPoint.position + direction * 50f).ToString());
            Debug.Log(typeConnection.ToString());
            Debug.Log("Direction for connect:" + direction);
        }


        private void PositionateCreatedChunk(ChunkData chunkData, ConnectionPoint connectionPoint)
        {
            Vector3 direction = Calculate.CalculateDirection(connectionPoint.PointForConnect.position, chunkData.RootPoint.position);
            Vector3 rootPointForCreatedChunk = CalculateRootPoint(chunkData.RootPoint.position, direction);

            ConnectCreatedChunk(direction);

            SetPositionForCreatedChunk(rootPointForCreatedChunk);
        }

        private void UpdateDataAboutCreatedChunk()
        {
            createdChunksList.Add(createdChunk);
            LevelGrid.AddLevelCell(createdChunk);
        }



        private void ConnectCreatedChunk(Vector3 directionWromWhichNeedConnect)
        {
            List<DirectionConnect> neededConnectDirections = new List<DirectionConnect>();
            List<DirectionConnect> freeConnectDirections = new List<DirectionConnect>();

            CalculateDirectionsForConnect(directionWromWhichNeedConnect, neededConnectDirections, freeConnectDirections);

            ConnectCreatedChunk(neededConnectDirections, freeConnectDirections);
        }

        private void CalculateDirectionsForConnect(Vector3 direction, List<DirectionConnect> needDirections,
                                                                     List<DirectionConnect> freeDirections)
        {
            needDirections.Add(new DirectionConnect(false, direction * -1));//backwards

            AddDirection(typeConnection.ForwardConnection, direction, needDirections, freeDirections);

            direction = Quaternion.Euler(0, 90, 0) * direction;

            AddDirection(typeConnection.RightConnection, direction, needDirections, freeDirections);

            direction *= -1;

            AddDirection(typeConnection.LeftConnection, direction, needDirections, freeDirections);
        }

        private void AddDirection(TypeConnection typeConnection, Vector3 direction, List<DirectionConnect> needDirections,
                                                                                    List<DirectionConnect> freeDirections)
        {
            if (typeConnection == TypeConnection.NeededForConnect)
                needDirections.Add(new DirectionConnect(false, direction));
            else if (typeConnection == TypeConnection.FreeForConnect)
                freeDirections.Add(new DirectionConnect(false, direction));
        }



        private void ConnectCreatedChunk(List<DirectionConnect> needDirections, List<DirectionConnect> freeDirections)
        {
            List<Vector3> directionConnectForChunk = CalculateDirectionConnectForCreatedChunk();

            int countNeedConnect;
            int countFreeConnect;

            foreach (Vector3 direction in directionConnectForChunk)
            {
                SameDirection(direction, needDirections);
                SameDirection(direction, freeDirections);
            }

            countNeedConnect = CalculateConnection(needDirections);
            countFreeConnect = CalculateConnection(freeDirections);

            if (IsFailedConnect(countNeedConnect, countFreeConnect, needDirections.Count, directionConnectForChunk.Count))
            {
                RotateCreatedChunk();

                RecalConnectCreatedChunk(needDirections, freeDirections);
            }
        }

        private List<Vector3> CalculateDirectionConnectForCreatedChunk()
        {
            ChunkData prefabData = createdChunk.GetComponent<ChunkData>();

            List<Vector3> directions = new List<Vector3>();
            Vector3 rootPoint = prefabData.RootPoint.position;

            foreach (ConnectionPoint point in prefabData.connectionPoints)
                directions.Add(Calculate.CalculateDirection(point.PointForConnect.position, rootPoint));

            return directions;
        }

        private void SameDirection(Vector3 direction, List<DirectionConnect> directions)
        {
            foreach (DirectionConnect connectedDirection in directions)
            {
                if (Vector3.Dot(direction, connectedDirection.Direction) > 0.9f)
                    connectedDirection.IsConnected = true;
            }
        }

        private int CalculateConnection(List<DirectionConnect> directions)
        {
            int countConnection = 0;

            foreach (DirectionConnect direction in directions)
            {
                if (direction.IsConnected)
                    countConnection++;
            }

            return countConnection;
        }

        private bool IsFailedConnect(int countNeedConnect, int countFreeConnect, int countNeedDirection, int countChunkConnectDirection)
        {
            return countNeedConnect != countNeedDirection || countNeedConnect + countFreeConnect != countChunkConnectDirection;
        }

        private void RotateCreatedChunk()
        {
            createdChunk.transform.Rotate(0, 90, 0);
        }

        private void RecalConnectCreatedChunk(List<DirectionConnect> needDirections, List<DirectionConnect> freeDirections)
        {
            UpdateValueDirection(needDirections);
            UpdateValueDirection(freeDirections);

            ConnectCreatedChunk(needDirections, freeDirections);
        }

        private void UpdateValueDirection(List<DirectionConnect> directions)
        {
            foreach (DirectionConnect direction in directions)
                direction.IsConnected = false;
        }


        private void SetPositionForCreatedChunk(Vector3 rootPoint) =>
            createdChunk.transform.position = rootPoint;

        private Vector3 CalculateRootPoint(Vector3 rootPoint, Vector3 direction) =>
            rootPoint + direction * chunkSetup.ChunkHeightAndWidth;
    }
}