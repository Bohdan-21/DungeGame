using Scripts.Infrastructure.Factory;
using UnityEngine;
using Zenject;

namespace Scripts.Enemy
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawSphere(transform.position, 0.5f);

            Gizmos.color = default;
        }
    }
}
