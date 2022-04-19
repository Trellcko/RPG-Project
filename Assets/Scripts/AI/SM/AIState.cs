using Trell.Core.StateMachinePattern;

namespace Trell.AI.States
{
    public class AIState : BaseState
    {
        protected AIBehaviour AIBehaviour;

        public AIState(StateMachine stateMachine, AIBehaviour aIBehaviour) : base(stateMachine)
        {
            AIBehaviour = aIBehaviour;
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

    }
}