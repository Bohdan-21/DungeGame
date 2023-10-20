namespace Scripts.Infrastructure.StateMachine
{
    public class GameLoopState : IState
    {
        private GameStateMachine _levelStateMachine;

        public GameLoopState(GameStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public void Enter()
        {
            //_levelStateMachine.Enter<DeathState>();
        }

        public void Exit()
        {
            
        }
    }
}