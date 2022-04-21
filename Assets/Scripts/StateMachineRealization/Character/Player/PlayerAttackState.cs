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
            _playerBehaviour.ClickHandler.HittedEnemyChanging += HittedEnemyChangedHandle;
            _playerBehaviour.Target.DownToZero += GoToState<PlayerMoveState>;
        }

        public override void Exit()
        {
            base.Exit();
            _playerBehaviour.ClickHandler.HittedEnemyChanging -= HittedEnemyChangedHandle;
            if (_playerBehaviour.Target != null)
            {
                _playerBehaviour.Target.DownToZero -= GoToState<PlayerMoveState>;
            }
        }

        private void HittedEnemyChangedHandle(Health newEnemy)
        {
            if(_playerBehaviour.ClickHandler.HittedEnemy != null)
            {
                _playerBehaviour.ClickHandler.HittedEnemy.DownToZero -= GoToState<PlayerMoveState>;
            }
            if (newEnemy == null)
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