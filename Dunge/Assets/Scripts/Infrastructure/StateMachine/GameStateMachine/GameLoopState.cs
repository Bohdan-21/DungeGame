using Scripts.UI.NameLocation;

namespace Scripts.Infrastructure.StateMachine
{
    public class GameLoopState : IState
    {
        private GameStateMachine _levelStateMachine;
        private INameLocationUI _nameLocationUI;

        public GameLoopState(GameStateMachine levelStateMachine, INameLocationUI nameLocationUI)
        {
            _levelStateMachine = levelStateMachine;
            _nameLocationUI = nameLocationUI;
        }

        public void Enter()
        {
            _nameLocationUI.ShowNameLocation();

            //_levelStateMachine.Enter<DeathState>();
        }

        public void Exit()
        {
            
        }
    }
}