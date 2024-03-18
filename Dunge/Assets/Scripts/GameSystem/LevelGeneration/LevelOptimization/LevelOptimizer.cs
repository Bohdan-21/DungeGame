using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.LevelGeneration.LevelOptimization
{
    public class LevelOptimizer : MonoBehaviour
    {
        private void Start()
        {
            LevelDisplayOptimization.Instance.StartOptimization(gameObject.transform);
        }
    }
}
