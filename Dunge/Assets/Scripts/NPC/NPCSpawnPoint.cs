using UnityEngine;

namespace Scripts.NPC
{
    public class NPCSpawnPoint : MonoBehaviour
    {
        public NPCType NPCName;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawSphere(transform.position, 0.5f);

            Gizmos.color = Color.white;
        }
    }
}
