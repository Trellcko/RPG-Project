using Trell.Core.StateMachinePattern;

namespace Trell.StateMachineRealization.Character
{
    public class DieState : BaseState
    {
        private CharacterBehaviour _characterBehaviour;
        public DieState(StateMachine stateMachine, CharacterBehaviour CharacterBehaviour) : base(stateMachine, CharacterBehaviour)
        {
            _characterBehaviour = CharacterBehaviour;
        }

        public override void Enter()
        {
            _characterBehaviour.DeathAnimator.Die();
        }
    }
}