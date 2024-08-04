using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;


namespace Scripts.GameSystem.LevelGeneration.Baker
{
    public class LevelBaker : MonoBehaviour, ILevelBaker
    {
        public NavMeshSurface navMeshSurface;

        public void BakeLevel()
        {
            navMeshSurface.BuildNavMesh();
        }
    }
}
