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
            _aIBehaviour.Mover.Stop();
            _aIBehaviour.MovementAnimator.SetSpeed(0);
        }

        public override void Update()
        {
            _aIBehaviour.MovementAnimator.SetSpeed(_aIBehaviour.Mover.GetSpeed());
            _aIBehaviour.TickTimeToAttack();
            if (_aIBehaviour.CanStartChasingPlayer)
            {
                GoToState<AIChaseState>();
            }
        }
        public override void FixedUpdate()
        {
            _aIBehaviour.Mover.SetTarget(_aIBehaviour.CurrentPatrolPoint.position);
        }
    }
}