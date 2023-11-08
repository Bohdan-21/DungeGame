using UnityEngine;

namespace Scripts.Enemy
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        public EnemyType enemyType;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawSphere(transform.position, 0.5f);

            Gizmos.color = default;
        }
    }
}
