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
            _levelStateMachine.Enter<InitializeLevelState>();
            //throw new System.NotImplementedException();
        }

        public void Exit()
        {
            //throw new System.NotImplementedException();
        }
    }
}
