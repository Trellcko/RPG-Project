namespace Trell.AI.FSM
{
    public class AIChasingState : BaseState
    {
        public AIChasingState(AIStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        { 
        }

        public override void Exit()
        {
            StateMachine.Mover.Stop();
            StateMachine.MovementAnimator.SetSpeed(0f);
        }

        public override void Update()
        {
            StateMachine.Mover.SetTarget(StateMachine.PlayerTransform.position);
            StateMachine.MovementAnimator.SetSpeed(StateMachine.Mover.GetSpeed());
            if(StateMachine.InRangeToStartAttack)
            {
                StateMachine.SetState<AIAttackState>();
            }
        }
    }
}