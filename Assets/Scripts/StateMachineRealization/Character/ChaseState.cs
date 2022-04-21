using Trell.Core.StateMachinePattern;

namespace Trell.StateMachineRealization.Character
{
    public class ChaseState : BaseState
    {
        private CharacterBehaviour _characterBehaviour;
        public ChaseState(StateMachine stateMachine, CharacterBehaviour aIBehaviour) : base(stateMachine, aIBehaviour)
        {
            _characterBehaviour = aIBehaviour;
        }

        public override void Enter()
        {
            _characterBehaviour.Health.DownToZero += GoToState<DieState>;
        }

        public override void Exit()
        {
            _characterBehaviour.Health.DownToZero -= GoToState<DieState>;
            _characterBehaviour.Mover.Stop();
            _characterBehaviour.MovementAnimator.SetSpeed(0f);
        }

        public override void FixedUpdate()
        {
            _characterBehaviour.Mover.SetTarget(_characterBehaviour.Target.transform.position);
        }

        public override void Update()
        {
            _characterBehaviour.TickTimeToAttack();
            _characterBehaviour.MovementAnimator.SetSpeed(_characterBehaviour.Mover.GetSpeed());
        }

    }
}