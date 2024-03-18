using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.LevelOptimization
{
    public interface ILevelDisplayOptimization
    {
        void StartOptimization(Transform targetForOptimization);
    }
}