using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine : IStateMachine
    {
        private Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private IState _activeState;

        public void AddState(IState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = GetState<TState>();

            if (state == null)
                return;

            ExitActiveState();

            _activeState = state;

            state.Enter();
        }

        private void ExitActiveState() => _activeState?.Exit();

        private IState GetState<TState>() where TState : class, IState
        {
            if (_states.TryGetValue(typeof(TState), out IState state))
                return state;
            return null;
        }
    }
}
