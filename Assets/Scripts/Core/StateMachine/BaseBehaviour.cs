using UnityEngine;

namespace Trell.Core.StateMachinePattern
{
	public abstract class BaseBehaviour : MonoBehaviour
	{
		protected StateMachine StateMachine;

		protected abstract void InitStateMachine();
	}
}