using Trell.Core.StateMachinePattern;

namespace Trell.AI.States
{
    public class AIAttackState : AIState
    {
        public AIAttackState(StateMachine stateMachine, AIBehaviour aIBehaviour) : base(stateMachine, aIBehaviour)
        {
        }

        public override void Enter()
        {
            
            AIBehaviour.Health.DownToZero += GoToState<AIDieState>;
            AIBehaviour.AttackingAnimator.Attacking += Attack;
            AIBehaviour.AttackingAnimator.StartAttack();
        }

        public override void Exit()
        {
            AIBehaviour.Health.DownToZero -= GoToState<AIDieState>;
            AIBehaviour.AttackingAnimator.Attacking -= Attack;
            AIBehaviour.AttackingAnimator.StopAttackImmediately();
        }

        public override void Update()
        {
            if(AIBehaviour.InRangeRangeToStartAttack == false)
            {
                GoToState<AIChasingState>();
            }
        }
        private void Attack()
        {
            AIBehaviour.Attacking.Attack(AIBehaviour.PlayerHealth);
        }

    }
}