namespace Trell.AI.FSM
{
    public class AIAttackState : BaseState
    {
        public AIAttackState(AIStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            StateMachine.AttackingAnimator.Attacking += Attack;
        }

        public override void Exit()
        {
            StateMachine.AttackingAnimator.Attacking -= Attack;
        }

        public override void Update()
        {
            if(StateMachine.InRangeToStartAttack == false)
            {
                StateMachine.SetState<AIChasingState>();
            }
        }
        private void Attack()
        {
            StateMachine.Attacking.Attack(StateMachine.PlayerHealth);
        }

    }
}