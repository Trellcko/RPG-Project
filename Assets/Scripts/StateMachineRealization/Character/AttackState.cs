using Trell.Core.StateMachinePattern;

namespace Trell.StateMachineRealization.Character
{
    public class AttackState : BaseState
    {
        private CharacterBehaviour _characterBehaviour;

        public AttackState(StateMachine stateMachine, CharacterBehaviour behaviour) : base(stateMachine, behaviour)
        {
            _characterBehaviour = behaviour;
        }

        public override void Enter()
        {
            _characterBehaviour.Health.DownToZero += GoToState<DieState>;
            _characterBehaviour.AttackingAnimator.Attacking += Attack;
            _characterBehaviour.AttackingAnimator.StartAttack();
        }

        public override void Exit()
        {
            _characterBehaviour.Health.DownToZero -= GoToState<DieState>;
            _characterBehaviour.AttackingAnimator.Attacking -= Attack;
            _characterBehaviour.AttackingAnimator.StopAttackImmediately();
        }

        public override void Update()
        {
            _characterBehaviour.transform.LookAt(_characterBehaviour.Target.transform);
        }

        protected virtual void Attack()
        {
            _characterBehaviour.Attacking.Attack(_characterBehaviour.Target);
        }
    }
}