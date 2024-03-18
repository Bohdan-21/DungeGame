using System;
using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration
{
    public static class Calculate
    {
        public static Vector3 CalculateDirection(Vector3 targetPosition, Vector3 currentPosition) =>
            (targetPosition - currentPosition).normalized;

        public static int CalculateRow(Vector3 rootPointForDetect, int ChunkHeightAndWidth) =>
            (int)MathF.Round(rootPointForDetect.z / ChunkHeightAndWidth, 0);

        public static int CalculateColumn(Vector3 rootPointForDetect, int ChunkHeightAndWidth) =>
            (int)MathF.Round(rootPointForDetect.x / ChunkHeightAndWidth, 0);
    }
}
