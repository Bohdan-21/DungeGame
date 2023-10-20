namespace Scripts.Infrastructure.StateMachine
{
    public interface IStateMachine
    {
        void AddState(IState state);
        void Enter<TState>() where TState : class, IState;
    }
}