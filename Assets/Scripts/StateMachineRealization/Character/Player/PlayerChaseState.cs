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
            _playerBehaviour.ClickHandler.HittedEnemyChanging += HittedEnemyChanged;
        }

        public override void Exit()
        {
            base.Exit();
            _playerBehaviour.ClickHandler.HittedEnemyChanging -= HittedEnemyChanged;
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
            if(_playerBehaviour.EnoughCloseToAttack)
            {
                GoToState<PlayerAttackState>();
            }
        }
    }
}