using Trell.Core.StateMachinePattern;

namespace Trell.AI.States
{
    public class AIChasingState : AIState
    {
        public AIChasingState(StateMachine stateMachine, AIBehaviour aIBehaviour) : base(stateMachine, aIBehaviour)
        {
        }

        public override void Enter()
        {
            AIBehaviour.Health.DownToZero += GoToState<AIDieState>;
        }

        public override void Exit()
        {
            AIBehaviour.Health.DownToZero -= GoToState<AIDieState>;
            AIBehaviour.Mover.Stop();
            AIBehaviour.MovementAnimator.SetSpeed(0f);
        }

        public override void FixedUpdate()
        {
            AIBehaviour.Mover.SetTarget(AIBehaviour.PlayerTransform.position);
        }

        public override void Update()
        {
            AIBehaviour.MovementAnimator.SetSpeed(AIBehaviour.Mover.GetSpeed());
            if(AIBehaviour.InRangeRangeToStartAttack)
            {
                GoToState<AIAttackState>();
            }
        }

    }
}