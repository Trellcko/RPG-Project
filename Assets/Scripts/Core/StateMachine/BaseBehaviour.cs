using UnityEngine;

namespace Trell.Core.StateMachinePattern
{
	public abstract class BaseBehaviour : MonoBehaviour
	{
		protected StateMachine StateMachine;

		protected abstract void InitStateMachine();

        private void Update()
        {
            StateMachine.Update();
        }

        private void FixedUpdate()
        {
            StateMachine.FixedUpdate();
        }
    }
}