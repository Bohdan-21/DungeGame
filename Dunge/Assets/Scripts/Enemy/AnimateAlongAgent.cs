using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Enemy
{
    public class AnimateAlongAgent : MonoBehaviour
    {
        private const float MinimalVelocity = 0.1f;

        public EnemyAnimator Animator;
        public NavMeshAgent Agent;

        private void Update()
        {
            if (IsMove())
                Animator.PlayMove(Agent.velocity.magnitude);
            else
                Animator.PlayStopMove();
        }

        private bool IsMove() =>
            Agent.velocity.magnitude > MinimalVelocity;
    }
}


