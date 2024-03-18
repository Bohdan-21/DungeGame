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

        private LevelSettings _levelSettings;
        private ChunkSetup _chunkSetup;

        private Transform _targetForOptimization;

        public int maxAvailableDistanceForDisplayingChunks = 1;

        private List<LevelCell> _chunkForDisplay = new List<LevelCell>();

        [Inject]
        private void Construct(LevelSettings levelSettings, ChunkSetup chunkSetup)
        {
            _levelSettings = levelSettings;
            _chunkSetup = chunkSetup;
        }

        private void Awake()
        {
            Instance = this;
        }

        public void StartOptimization(Transform targetForOptimization)
        {
            _targetForOptimization = targetForOptimization;

            StartCoroutine(StartOptimization());
        }

        private IEnumerator StartOptimization()
        {
            yield return new WaitForSeconds(5);

            if (_levelSettings.levelGrid.currentSpawnedChunk == 1)
                yield break;

            while (true)
            {
                Debug.Log("Optimization");

                int row = Calculate.CalculateRow(_targetForOptimization.position, _chunkSetup.ChunkHeightAndWidth);
                int column = Calculate.CalculateColumn(_targetForOptimization.position, _chunkSetup.ChunkHeightAndWidth);

                RecalculateChunksForDisplay(row, column);

                DisplayChunks();

                yield return new WaitForSeconds(2);
            }
        }

        private void RecalculateChunksForDisplay(int row, int column)
        {
            _chunkForDisplay.Clear();

            LevelCell levelCell;

            for (int i = row - maxAvailableDistanceForDisplayingChunks; i <= row + maxAvailableDistanceForDisplayingChunks; i++)
            {
                for (int j = column - maxAvailableDistanceForDisplayingChunks; j <= column + maxAvailableDistanceForDisplayingChunks; j++)
                {
                    levelCell = _levelSettings.levelGrid.GetLevelCell(i, j);

                    if (levelCell != null)
                        _chunkForDisplay.Add(levelCell);

                }
            }
        }

        private void DisplayChunks()
        {
            bool isDisplaying;

            foreach (LevelCell levelCell in _levelSettings.levelGrid.LevelCells)
            {
                isDisplaying = false;

                foreach (LevelCell cellForDisplay in _chunkForDisplay)
                {
                    if (levelCell.Row == cellForDisplay.Row && levelCell.Column == cellForDisplay.Column)
                    {
                        if (!levelCell.chunkData.gameObject.activeSelf)
                            levelCell.chunkData.Show();

                        isDisplaying = true;
                    }

                    if (!isDisplaying)
                    {
                        levelCell.chunkData.Hide();
                    }
                }
            }
        }
    }
}
