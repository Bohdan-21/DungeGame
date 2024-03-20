using Scripts.GameSystem.LevelGeneration.DataChunk;
using Scripts.GameSystem.LevelGeneration.Grid;
using Scripts.GameSystem.LevelGeneration.LevelSetting;
using Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration.Setup;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.LevelGeneration.LevelOptimization
{
    public class LevelDisplayOptimization : MonoBehaviour, ILevelDisplayOptimization
    {
        public static LevelDisplayOptimization Instance;

        private LevelGrid _levelGrid;
        private ChunkSetup _chunkSetup;

        private Transform _targetForOptimization;

        public int maxAvailableDistanceForDisplayingChunks = 1;

        private List<LevelCell> _chunkForDisplay = new List<LevelCell>();

        private List<Vector2Int> _visibleChunks = new List<Vector2Int>();
        private List<Vector2Int> _unvisibleChunks = new List<Vector2Int>();

        [Inject]
        private void Construct(LevelGrid levelGrid, ChunkSetup chunkSetup)
        {
            _levelGrid = levelGrid;
            _chunkSetup = chunkSetup;
        }

        private void Awake()
        {
            Instance = this;
        }

        public void StartOptimization(Transform targetForOptimization)
        {
            _targetForOptimization = targetForOptimization;

            DeactivateInvisibleChunk();

            StartCoroutine(StartOptimization());
        }

        private void DeactivateInvisibleChunk()
        {
            int row = Calculate.CalculateRow(_targetForOptimization.position, _chunkSetup.ChunkHeightAndWidth);
            int column = Calculate.CalculateColumn(_targetForOptimization.position, _chunkSetup.ChunkHeightAndWidth);

            CalculateVisibleAndUnvisibleChunks(row, column);

            DeactivateAllUnvisibleChunks();
        }

        private IEnumerator StartOptimization()
        {
            yield return new WaitForSeconds(5);

            if (_levelGrid.LevelCells.Count == 1)
                yield break;

            while (true)
            {
                Debug.Log("Optimization");

                int row = Calculate.CalculateRow(_targetForOptimization.position, _chunkSetup.ChunkHeightAndWidth);
                int column = Calculate.CalculateColumn(_targetForOptimization.position, _chunkSetup.ChunkHeightAndWidth);

                CalculateVisibleAndUnvisibleChunks(row, column);

                ActivateVisibleChunks();

                DeactiviteUnvisibleChunks();

                yield return new WaitForSeconds(2);
            }
        }

        private void ActivateVisibleChunks()
        {
            for(int i = 0; i < _visibleChunks.Count; i++)
            {
                _levelGrid.GetLevelCell(_visibleChunks[i].x, _visibleChunks[i].y).chunkData.Show();
            }
        }

        private void DeactiviteUnvisibleChunks()
        {
            for(int i = 0; i < _unvisibleChunks.Count; i++)
            {
                _levelGrid.GetLevelCell(_unvisibleChunks[i].x, _unvisibleChunks[i].y).chunkData.Hide();
            }
        }

        private void CalculateVisibleAndUnvisibleChunks(int row, int column)
        {
            List<Vector2Int> visibleChunks = new List<Vector2Int>();

            for (int i = row - maxAvailableDistanceForDisplayingChunks; i <= row + maxAvailableDistanceForDisplayingChunks; i++)
            {
                for (int j = column - maxAvailableDistanceForDisplayingChunks; j <= column + maxAvailableDistanceForDisplayingChunks; j++)
                {
                    if (_levelGrid.GetLevelCell(i, j) != null)
                        visibleChunks.Add(new Vector2Int(i, j));
                }
            }

            if (_visibleChunks.Count == 0)
            {
                _visibleChunks = visibleChunks;
                return;
            }

            _unvisibleChunks.Clear();

            bool isNeedHide;

            for(int i = 0; i < _visibleChunks.Count;i++)
            {
                isNeedHide = true;

                for(int j = 0; j < visibleChunks.Count;j++)
                {
                    if (_visibleChunks[i] == visibleChunks[j])
                        isNeedHide = false;
                }

                if(isNeedHide)
                    _unvisibleChunks.Add(_visibleChunks[i]);
            }

            _visibleChunks = visibleChunks;
        }

        private void DeactivateAllUnvisibleChunks()
        {
            bool isNeedHide;

            foreach (var cell in _levelGrid.LevelCells)
            {
                isNeedHide = true;

                foreach(var coordinate in _visibleChunks)
                {
                    if(cell.Row == coordinate.x && cell.Column == coordinate.y)
                    {
                        isNeedHide = false;
                    }
                }

                if(isNeedHide)
                {
                    cell.chunkData.Hide();
                }
            }
        }
    }
}
