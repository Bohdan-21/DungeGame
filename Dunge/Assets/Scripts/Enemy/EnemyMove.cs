using Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Scripts.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        private Transform _target;

        public float minDistance = 1.0f;

        [Inject]
        private void Construct(PlayerBehaviour player)
        {
            _target = player.transform;
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _target.position) >= minDistance)
                _navMeshAgent.SetDestination(_target.position);
        }
    }
}