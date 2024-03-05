using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration
{
    public static class Calculate
    {
        public static Vector3 CalculateDirection(Vector3 targetPosition, Vector3 currentPosition) =>
            (targetPosition - currentPosition).normalized;
    }
}
