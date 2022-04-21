
using Trell.Core.StateMachinePattern;

namespace Trell.StateMachineRealization.Character.AI
{
    public class AIChaseState : ChaseState
    {
        private AIBehaviour _aIBehaviour;
        public AIChaseState(StateMachine stateMachine, AIBehaviour aIBehaviour) : base(stateMachine, aIBehaviour)
        {
            _aIBehaviour = aIBehaviour;
        }

        public override void Enter()
        {
            base.Enter();
            _aIBehaviour.Target.DownToZero += GoToState<AIPatrolState>;
        }


        public override void Exit()
        {
            base.Exit();
            _aIBehaviour.Target.DownToZero -= GoToState<AIPatrolState>;
        }

        public override void Update()
        {
            base.Update();
            if(_aIBehaviour.IsPlayerFarAway)
            {
                GoToState<AIPatrolState>();
                return;
            }
            if(_aIBehaviour.EnoughCloseToAttack)
            {
                GoToState<AIAttackState>();
                return;
            }
        }
    }
}