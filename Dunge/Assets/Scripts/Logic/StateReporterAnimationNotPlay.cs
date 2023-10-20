using Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Logic
{
    public class StateReporterAnimationNotPlay : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            animator.GetComponent<PlayerAnimator>().StopPlayAnimation();
        }
    }
}