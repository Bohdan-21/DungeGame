using UnityEngine;

namespace Scripts.Infrastructure.StateMachine
{
    public class DeathState : IState
    {
        private GameStateMachine _gameStateMachine;

        public DeathState(GameStateMachine levelStateMachine)
        {
            _gameStateMachine = levelStateMachine;
        }

        public void Enter()
        {
            //перезагрузить сцену

            _gameStateMachine.Enter<ReloadLevelState>();
        }

        public void Exit()
        {
            
        }
    }
}