using Trell.CombatSystem;
using Trell.Core.StateMachinePattern;

namespace Trell.StateMachineRealization.Character.Player
{
    public class PlayerChaseState : ChaseState
    {
        private PlayerBehaviour _playerBehaviour;
        public PlayerChaseState(StateMachine stateMachine, PlayerBehaviour playerBehaviour) : base(stateMachine, playerBehaviour)
        {
            _playerBehaviour = playerBehaviour;
        }

        public override void Enter()
        {
            base.Enter();
            _playerBehaviour.ClickHandler.HittedEnemyChanged += HittedEnemyChanged;
        }

        public override void Exit()
        {
            base.Exit();
            _playerBehaviour.ClickHandler.HittedEnemyChanged -= HittedEnemyChanged;
        }

        private void HittedEnemyChanged(Health enemy)
        {
            if (enemy == null)
            {
                GoToState<PlayerMoveState>();
            }
        }

        public override void Update()
        {
            base.Update();
            if(_playerBehaviour.InRangeRangeToStartAttack)
            {
                GoToState<PlayerAttackState>();
            }
        }
    }
}