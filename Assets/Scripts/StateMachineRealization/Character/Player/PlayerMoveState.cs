using Trell.CombatSystem;
using Trell.Core.StateMachinePattern;

namespace Trell.StateMachineRealization.Character.Player
{
    public class PlayerMoveState : BaseState
    {
        private PlayerBehaviour _playerBehaviour;


        public PlayerMoveState(StateMachine stateMachine, PlayerBehaviour behaviour) : base(stateMachine, behaviour)
        {
            _playerBehaviour = behaviour;
        }

        public override void Enter()
        {
            _playerBehaviour.ClickHandler.HittedEnemyChanged += HittedEnemyChangedHandle;
        }

        public override void Exit()
        {
            _playerBehaviour.ClickHandler.HittedEnemyChanged -= HittedEnemyChangedHandle;
        }

        public override void Update()
        {
            _playerBehaviour.MovementAnimator.SetSpeed(_playerBehaviour.Mover.GetSpeed());
        }

        public override void FixedUpdate()
        {
            _playerBehaviour.Mover.SetTarget(_playerBehaviour.LastClickedPosition);
        }

        private void HittedEnemyChangedHandle(Health enemy)
        {
            if (enemy != null)
            {
                GoToState<PlayerChaseState>();
            }
        }
    }
}