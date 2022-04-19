using Trell.Core.StateMachinePattern;

namespace Trell.AI.States
{
    public class AIDieState : AIState
    {
        public AIDieState(StateMachine stateMachine, AIBehaviour aIBehaviour) : base(stateMachine, aIBehaviour)
        {
        }

        public override void Enter()
        {
            AIBehaviour.DeathAnimator.Die();
        }

        public override void Exit()
        {
        }
    }
}