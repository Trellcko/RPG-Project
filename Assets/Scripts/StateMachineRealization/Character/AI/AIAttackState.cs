using Trell.Core.StateMachinePattern;

namespace Trell.StateMachineRealization.Character.AI
{
    public class AIAttackState : AttackState
    {
        private AIBehaviour _aIBehaviour;
        public AIAttackState(StateMachine stateMachine, AIBehaviour aIBehaviour) : base(stateMachine, aIBehaviour)
        {
            _aIBehaviour = aIBehaviour;
        }

        public override void Update()
        {
            base.Update();
            if (_aIBehaviour.EnoughCloseToAttack == false)
            {
                GoToState<AIChaseState>();
            }
        }

    }
}