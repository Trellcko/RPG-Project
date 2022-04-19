using Trell.Core.StateMachinePattern;

namespace Trell.StateMachineRealization.Character.AI
{
    public class AIChasingState : BaseState
    {
        private AIBehaviour _aIBehaviour;
        public AIChasingState(StateMachine stateMachine, AIBehaviour aIBehaviour) : base(stateMachine, aIBehaviour)
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
            _aIBehaviour.Mover.Stop();
            _aIBehaviour.MovementAnimator.SetSpeed(0f);
        }

        public override void FixedUpdate()
        {
            _aIBehaviour.Mover.SetTarget(_aIBehaviour.PlayerTransform.position);
        }

        public override void Update()
        {
            _aIBehaviour.MovementAnimator.SetSpeed(_aIBehaviour.Mover.GetSpeed());
            if(_aIBehaviour.InRangeRangeToStartAttack)
            {
                GoToState<AIAttackState>();
            }
        }

    }
}