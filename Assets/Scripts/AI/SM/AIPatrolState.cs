using Trell.Core.StateMachinePattern;

namespace Trell.AI.States
{
    public class AIPatrolState : AIState
    {
        public AIPatrolState(StateMachine stateMachine, AIBehaviour aIBehaviour) : base(stateMachine, aIBehaviour)
        {
        }

        public override void Enter()
        {
            AIBehaviour.Health.DownToZero += GoToState<AIDieState>;
        }

     
        public override void Exit()
        {
            AIBehaviour.Health.DownToZero -= GoToState<AIDieState>;
        }

        public override void Update()
        {
            if (AIBehaviour.InRangeToTriggerChasing)
            {
                GoToState<AIChasingState>();
            }
        }
    }
}