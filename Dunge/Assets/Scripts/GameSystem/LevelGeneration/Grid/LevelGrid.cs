using Scripts.GameSystem.LevelGeneration.DataChunk;
using Scripts.GameSystem.LevelGeneration.LevelSetting;
using Scripts.Services.PlayerProgressService;
using Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration.Setup;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.LevelGeneration.Grid
{
    public class LevelGrid
    {
        private List<LevelCell> _levelCells = new List<LevelCell>();
        private ChunkSetup _chunkSetup;
        private IPlayerProgressService _progressService;

        private int _currentSpawnedChunk = 1;

        public LevelGrid(ChunkSetup chunkSetup, LevelData levelData, IPlayerProgressService progressService)
        {
            _chunkSetup = chunkSetup;
            _progressService = progressService;

            AddPreparedChunks(levelData);
        }

        public List<LevelCell> LevelCells => _levelCells;


        private void AddPreparedChunks(LevelData levelData)
        {
            int row;
            int column;

            foreach (ChunkData chunk in levelData.PreparedChunks)
            {
                row = Calculate.CalculateRow(chunk.RootPoint.position, _chunkSetup.ChunkHeightAndWidth);
                column = Calculate.CalculateColumn(chunk.RootPoint.position, _chunkSetup.ChunkHeightAndWidth);

                _levelCells.Add(new LevelCell(row, column, chunk));

                _currentSpawnedChunk++;
            }
        }


        public TypeConnectionForCell DetectTypeConnection(Vector3 rootPointPrefChunk, Vector3 connectPointPrevChunk)
        {
            Vector3 direction = Calculate.CalculateDirection(connectPointPrevChunk, rootPointPrefChunk);
            Vector3 rootPointForNewChunk = CalculatePositionForChunk(rootPointPrefChunk, direction);

            if (IsLevelCellOccupied(GetLevelCell(rootPointForNewChunk)))
                return null;

            return CalculateTypeConnection(rootPointForNewChunk, direction);
        }

        private Vector3 CalculatePositionForChunk(Vector3 prevChunkRootPoint, Vector3 direction) =>
            prevChunkRootPoint + direction * _chunkSetup.ChunkHeightAndWidth;

        private bool IsLevelCellOccupied(LevelCell levelCell) => 
            levelCell != null;

        private TypeConnectionForCell CalculateTypeConnection(Vector3 rootPoint, Vector3 direction)
        {
            TypeConnection ForwardConnection;
            TypeConnection RightConnection;
            TypeConnection LeftConnection;

            ForwardConnection = CalculateConnection(rootPoint, direction);

            direction = RotateVectorToRight(direction);

            RightConnection = CalculateConnection(rootPoint, direction);

            direction *= -1;

            LeftConnection = CalculateConnection(rootPoint, direction);

            return CreateTypeConnectionForCell(ForwardConnection, RightConnection, LeftConnection);
        }

        private TypeConnection CalculateConnection(Vector3 pointForSpawn, Vector3 direction)
        {
            Vector3 neigbourCell = CalculatePositionForChunk(pointForSpawn, direction);

            LevelCell levelCell = GetLevelCell(neigbourCell);

            if (!IsLevelCellOccupied(levelCell))
                return TypeConnection.FreeForConnect;

            ChunkData neigbourPrefabData = levelCell.chunkData;

            Vector3 neigbourDirection;

            foreach (ConnectionPoint point in neigbourPrefabData.connectionPoints)
            {
                neigbourDirection = Calculate.CalculateDirection(point.PointForConnect.position, neigbourPrefabData.RootPoint.position);

                if (Vector3.Dot(neigbourDirection, direction) < -0.9f)
                    return TypeConnection.NeededForConnect;
            }

            return TypeConnection.LockedForConnect;
        }

        private TypeConnectionForCell CreateTypeConnectionForCell(TypeConnection ForwardConnection, TypeConnection RightConnection, TypeConnection LeftConnection)
        {
            TypeConnectionForCell typeConnection = new TypeConnectionForCell(ForwardConnection, RightConnection, LeftConnection);

            if (IsNeedToStopLevelGeneration(typeConnection))//принудительно прерываем спавн
                typeConnection = new TypeConnectionForCell(TypeConnection.LockedForConnect, TypeConnection.LockedForConnect, TypeConnection.LockedForConnect);
            return typeConnection;
        }

        private bool IsNeedToStopLevelGeneration(TypeConnectionForCell typeConnection) =>
            _currentSpawnedChunk > _chunkSetup.MaxAvailableSpawnedChunk + _progressService.PlayerProgress.LevelData.LevelDunge && typeConnection.NeedConnectCount == 0;


        public void AddLevelCell(GameObject createdChunk)
        {
            ChunkData dataAboutCreatedChunk = createdChunk.GetComponent<ChunkData>();
            Vector3 rootPointForCreatedChunk = dataAboutCreatedChunk.RootPoint.position;

            Vector3 neigbourRootPoint;
            Vector3 directionForConnectPoint;

            LevelCell neigbourLevelCell;

            foreach (ConnectionPoint point in dataAboutCreatedChunk.connectionPoints)
            {
                directionForConnectPoint = Calculate.CalculateDirection(point.PointForConnect.position, rootPointForCreatedChunk);
                neigbourRootPoint = CalculatePositionForChunk(rootPointForCreatedChunk, directionForConnectPoint);

                neigbourLevelCell = GetLevelCell(neigbourRootPoint);

                if (IsLevelCellOccupied(neigbourLevelCell))
                    MarkConnectionPoint(directionForConnectPoint, neigbourLevelCell, point);
            }

            AddNewLevelCell(dataAboutCreatedChunk);
        }

        private void MarkConnectionPoint(Vector3 directionForConnectPoint, LevelCell neigbourLevelCell, ConnectionPoint connectPoint)
        {
            Vector3 neigbourDirection;
            ChunkData neigbourChunkData;

            neigbourChunkData = neigbourLevelCell.chunkData;

            foreach (ConnectionPoint neigbourPoint in neigbourChunkData.connectionPoints)
            {
                neigbourDirection = Calculate.CalculateDirection(neigbourPoint.PointForConnect.position, neigbourChunkData.RootPoint.position);

                if (Vector3.Dot(neigbourDirection, directionForConnectPoint) == -1)
                {
                    connectPoint.IsPointConnect = true;
                    neigbourPoint.IsPointConnect = true;
                }
            }
        }

        private void AddNewLevelCell(ChunkData dataAboutCreatedChunk)
        {
            int rowCell = Calculate.CalculateRow(dataAboutCreatedChunk.RootPoint.position, _chunkSetup.ChunkHeightAndWidth);
            int columnCell = Calculate.CalculateColumn(dataAboutCreatedChunk.RootPoint.position, _chunkSetup.ChunkHeightAndWidth);

            _levelCells.Add(new LevelCell(rowCell, columnCell, dataAboutCreatedChunk));

            _currentSpawnedChunk++;
        }


        private Vector3 RotateVectorToRight(Vector3 direction) => 
            Quaternion.Euler(0, 90, 0) * direction;

        private LevelCell GetLevelCell(Vector3 rootPointChunk)
        {
            int row = Calculate.CalculateRow(rootPointChunk, _chunkSetup.ChunkHeightAndWidth);
            int column = Calculate.CalculateColumn(rootPointChunk, _chunkSetup.ChunkHeightAndWidth);

            return GetLevelCell(row, column);
        }

        public LevelCell GetLevelCell(int row, int column)
        {
            foreach (LevelCell gridCell in _levelCells)
                if (gridCell.Row == row && gridCell.Column == column)
                    return gridCell;
            return null;
        }
    }
}
