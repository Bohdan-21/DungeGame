using UnityEngine;
using Zenject;

namespace Scripts.GameSystem.LevelGeneration.LevelOptimization
{
    public class LevelOptimizer : MonoBehaviour
    {
        private ILevelDisplayOptimization _levelOptimizator;

        [Inject]
        private void Construct(ILevelDisplayOptimization levelOptimizator)
        {
            _levelOptimizator = levelOptimizator;
        }

        private void Start()
        {
            //_levelOptimizator.StartOptimization(gameObject.transform);
        }
    }
}
