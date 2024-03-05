using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.GameSystem.LevelGeneration.Baker
{
    public class LevelBaker : MonoBehaviour
    {
        public NavMeshSurface navMeshSurface;

        public IEnumerator BakeLevel()
        {
            yield return null;
            navMeshSurface.BuildNavMesh();
        }
    }
}
