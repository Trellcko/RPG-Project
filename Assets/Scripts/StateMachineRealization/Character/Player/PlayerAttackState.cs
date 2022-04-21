using Trell.CombatSystem;
using Trell.Core.StateMachinePattern;

namespace Trell.StateMachineRealization.Character.Player
{
    public class PlayerAttackState : AttackState
    {
        private PlayerBehaviour _playerBehaviour;
        public PlayerAttackState(StateMachine stateMachine, PlayerBehaviour behaviour) : base(stateMachine, behaviour)
        {
            _playerBehaviour = behaviour;
        }

        public override void Enter()
        {
            base.Enter();
            _playerBehaviour.ClickHandler.HittedEnemyChanged += HittedEnemyChangedHandle;
        }

        public override void Exit()
        {
            base.Exit();
            _playerBehaviour.ClickHandler.HittedEnemyChanged += HittedEnemyChangedHandle;
        }

        private void HittedEnemyChangedHandle(Health enemy)
        {
            if (enemy == null)
            {
                GoToState<PlayerMoveState>();
            }
        }

        public override void Update()
        {
            base.Update();
            if (_playerBehaviour.EnoughCloseToAttack == false)
            {
                GoToState<PlayerChaseState>();
            }
        }
    }
}