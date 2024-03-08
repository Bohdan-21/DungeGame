using System.Collections;
using UnityEngine;

namespace Scripts.Infrastructure.StateMachine
{
    public class GenerateLevelState : IState
    {
        private GameStateMachine _levelStateMachine;

        public GenerateLevelState(GameStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public void Enter()
        {

            CompleteGenerateLevel();
            //throw new System.NotImplementedException();
        }

        private void CompleteGenerateLevel()
        {
            _levelStateMachine.Enter<InitializeLevelState>();
        }

        public void Exit()
        {
            //throw new System.NotImplementedException();
        }
    }
}
