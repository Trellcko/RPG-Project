using Trell.Core.StateMachinePattern;

namespace Trell.StateMachineRealization.Character.AI
{
    public class AISuspiciousState : BaseState
    {
        private AIBehaviour _aiBehaviour;
        public AISuspiciousState(StateMachine stateMachine, AIBehaviour behaviour) : base(stateMachine, behaviour)
        {
            _aiBehaviour = behaviour;
        }

        public override void Enter()
        {
            _aiBehaviour.ResetSuspuciousTime();
        }

        public override void Update()
        {
            _aiBehaviour.TickSuspiciousTime();
            if(_aiBehaviour.IsSupsicious == false)
            {
                GoToState<AIPatrolState>();
                return;
            }
            if(_aiBehaviour.CanStartChasingPlayer)
            {
                GoToState<AIChaseState>();
                return;
            }
        }

    }
}