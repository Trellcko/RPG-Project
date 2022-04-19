using Trell.Core.StateMachinePattern;

namespace Trell.StateMachineRealization.Character.AI
{
    public class AIPatrolState : BaseState
    {
        private AIBehaviour _aIBehaviour;
        public AIPatrolState(StateMachine stateMachine, AIBehaviour aIBehaviour) : base(stateMachine, aIBehaviour)
        {
            _aIBehaviour = aIBehaviour;
        }

        public override void Enter()
        {
            _aIBehaviour.Health.DownToZero += GoToState<DieState>;
        }

     
        public override void Exit()
        {
            _aIBehaviour.Health.DownToZero -= GoToState<DieState>;
        }

        public override void Update()
        {
            if (_aIBehaviour.InRangeToTriggerChasing)
            {
                GoToState<AIChasingState>();
            }
        }
    }
}