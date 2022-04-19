using System;
using System.Collections.Generic;
using UnityEngine;

namespace Trell.Core.StateMachinePattern
{
	public class StateMachine
	{
		private Dictionary<Type, BaseState> _states;

        private BaseState _currentState;

        public void InitStateMachine(Dictionary<Type, BaseState> states)
        {
            _states = states;
        }

        public void Update()
        {
            _currentState?.Update();
        }

        public void FixedUpdate()
        {
            _currentState?.FixedUpdate();
        }

        public void SetState<T>() where T : BaseState
        {
            _currentState?.Exit();
            if (_states.ContainsKey(typeof(T)))
            {
                BaseState state = _states[typeof(T)];
                _currentState = state;
                _currentState.Enter();
                return;
            }
            Debug.LogError("State: " + typeof(T).Name + " is not inclued");

        }
    }
}