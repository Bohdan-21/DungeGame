using Scripts.GameSystem.LevelGeneration.Grid;
using Scripts.StaticData.GameConfigData.GameSystem.LevelGeneration.Setup;
using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.LevelGeneration.Grid.Gizmo
{
    public class LevelGridDrawer : MonoBehaviour
    {
        private LevelGrid _levelGrid;
        private ChunkSetup _chunkSetup;

        public Vector3 sizeGridCell;
        public int maxSizeForGizmosMap;

        [Inject]
        private void Construct(LevelGrid levelGrid, ChunkSetup chunkSetup)
        {
            _levelGrid = levelGrid;
            _chunkSetup = chunkSetup;
        }

        private void Awake()
        {
            sizeGridCell = new Vector3(_chunkSetup.ChunkHeightAndWidth, 10, _chunkSetup.ChunkHeightAndWidth);
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Gizmos.color = Color.cyan;
                int row;
                int column;

                int halfSizeMap = maxSizeForGizmosMap / 2;

                for (int i = 0; i < maxSizeForGizmosMap; i++)
                {
                    if (i > halfSizeMap)
                        row = -(i % halfSizeMap);
                    else
                        row = i;

                    for (int j = 0; j < maxSizeForGizmosMap; j++)
                    {
                        if (j > halfSizeMap)
                            column = -(j % halfSizeMap);
                        else
                            column = j;

                        DrawCells(row, column);
                    }
                }

                Gizmos.color = Color.white;
            }
        }

        private void DrawCells(int row, int column)
        {
            ChangeGizmosColor(row, column);

            Gizmos.DrawCube(new Vector3(0 + column * _chunkSetup.ChunkHeightAndWidth, 0, 0 + row * _chunkSetup.ChunkHeightAndWidth),
                            sizeGridCell);
        }

        private static void ChangeGizmosColor(int row, int column)
        {
            Color firstColor = Color.yellow;
            Color secondColor = Color.green;

            firstColor.a = 0.25f;
            secondColor.a = 0.25f;

            if (row % 2 == 0)
            {
                if (column % 2 == 0)
                    Gizmos.color = firstColor;
                else
                    Gizmos.color = secondColor;
            }
            else
            {
                if (column % 2 == 0)
                    Gizmos.color = secondColor;
                else
                    Gizmos.color = firstColor;
            }
        }
    }
}
