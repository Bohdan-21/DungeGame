using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrastructure.StateMachine
{
    public class MainStateMachine : IStateMachine
    {
        private IState _activeState;
        private Dictionary<Type, IState> _states = new Dictionary<Type, IState>();

        public void AddState(IState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = GetState<TState>();

            if (state == null)
                return;

            ExitFromActiveState();

            _activeState = state;

            state.Enter();
        }

        private IState GetState<TState>() where TState : class, IState
        {
            if (_states.TryGetValue(typeof(TState), out IState state))
                return state;
            return null;
        }

        private void ExitFromActiveState() =>
            _activeState?.Exit();
    }


}