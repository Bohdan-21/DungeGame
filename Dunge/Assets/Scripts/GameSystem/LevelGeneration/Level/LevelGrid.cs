using Scripts.GameSystem.LevelGeneration.DataChunk;
using Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration.Setup;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.Level
{
    public class LevelGrid : MonoBehaviour
    {
        [SerializeField] private List<LevelCell> _levelCells;
        [SerializeField] private ChunkSetup _chunkSetup;
        
        public int currentSpawnedChunk = 1;

        public List<LevelCell> LevelCells => _levelCells;

        public TypeConnectionForCell DetectTypeConnection(Vector3 prevChunkRootPoint, Vector3 connectPointPrevChunk)
        {
            Vector3 direction = Calculate.CalculateDirection(connectPointPrevChunk, prevChunkRootPoint);
            Vector3 rootPointForNewChunk = CalculatePositionForChunk(prevChunkRootPoint, direction);

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

            ChunkData neigbourPrefabData = levelCell.LevelPrefabData;

            Vector3 neigbourDirection;

            foreach (ConnectionPoint point in neigbourPrefabData.connectionPoints)
            {
                neigbourDirection = Calculate.CalculateDirection(point.pointForConnect.position, neigbourPrefabData.RootPoint.position);

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
            currentSpawnedChunk > _chunkSetup.MaxAvailableSpawnedChunk && typeConnection.NeedConnectCount == 0;


        public void AddLevelCell(GameObject createdChunk)
        {
            ChunkData dataAboutCreatedChunk = createdChunk.GetComponent<ChunkData>();
            Vector3 rootPointForCreatedChunk = dataAboutCreatedChunk.RootPoint.position;

            Vector3 neigbourRootPoint;
            Vector3 directionForConnectPoint;

            LevelCell neigbourLevelCell;

            foreach (ConnectionPoint point in dataAboutCreatedChunk.connectionPoints)
            {
                directionForConnectPoint = Calculate.CalculateDirection(point.pointForConnect.position, rootPointForCreatedChunk);
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

            neigbourChunkData = neigbourLevelCell.LevelPrefabData;

            foreach (ConnectionPoint neigbourPoint in neigbourChunkData.connectionPoints)
            {
                neigbourDirection = Calculate.CalculateDirection(neigbourPoint.pointForConnect.position, neigbourChunkData.RootPoint.position);

                if (Vector3.Dot(neigbourDirection, directionForConnectPoint) == -1)
                {
                    connectPoint.isPointConnect = true;
                    neigbourPoint.isPointConnect = true;
                }
            }
        }

        private void AddNewLevelCell(ChunkData dataAboutCreatedChunk)
        {
            int rowCell = CalculateRow(dataAboutCreatedChunk.RootPoint.position);
            int columnCell = CalculateColumn(dataAboutCreatedChunk.RootPoint.position);

            _levelCells.Add(new LevelCell(rowCell, columnCell, dataAboutCreatedChunk));

            currentSpawnedChunk++;
        }


        private int CalculateRow(Vector3 rootPointForDetect) =>
            (int)MathF.Round(rootPointForDetect.z / _chunkSetup.ChunkHeightAndWidth, 0);

        private int CalculateColumn(Vector3 rootPointForDetect) =>
            (int)MathF.Round(rootPointForDetect.x / _chunkSetup.ChunkHeightAndWidth, 0);

        private Vector3 RotateVectorToRight(Vector3 direction) => 
            Quaternion.Euler(0, 90, 0) * direction;


        private LevelCell GetLevelCell(Vector3 rootPointChunk)
        {
            int row = CalculateRow(rootPointChunk);
            int column = CalculateColumn(rootPointChunk);

            return GetLevelCell(row, column);
        }

        private LevelCell GetLevelCell(int row, int column)
        {
            foreach (LevelCell gridCell in _levelCells)
                if (gridCell.Row == row && gridCell.Column == column)
                    return gridCell;
            return null;
        }
    }
}
