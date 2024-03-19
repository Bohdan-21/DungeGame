using System.Collections;
using UnityEngine;
using UnityEngine.AI;

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
