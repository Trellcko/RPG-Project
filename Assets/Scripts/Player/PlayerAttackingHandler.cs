using Trell.Animation.Character;
using Trell.CombatSystem;
using Trell.Utils;
using UnityEngine;

namespace Trell.Player
{
    public class PlayerAttackingHandler : MonoBehaviour
	{
		[SerializeField] private Attacking _attacking;
        [SerializeField] private AttackingAnimator _attackingAnimator;

		[SerializeField] private PlayerClickHandler _playerClickListener;

        [SerializeField] private CheckingForRange _checkingForRange;
        
        [Space]
        [Range(0,5)]
        [SerializeField] private float _timeBetweenAttacks;

        public bool IsAttacking = false;

        private Health _enemy => _playerClickListener.HittedEnemy;

        private float _timeSinceLastAttack;
        
        private bool _hasTarget => _enemy != null;
        private bool _isReloaded => _timeSinceLastAttack > _timeBetweenAttacks;

        private void OnEnable()
        {
            _attackingAnimator.Attacking += AttackHittedEnemy;
        }

        private void OnDisable()
        {
            _attackingAnimator.Attacking -= AttackHittedEnemy;
        }

        private void Start()
        {
            _timeSinceLastAttack = _timeBetweenAttacks;
        }

        private void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;
            if (_hasTarget && _enemy.IsDied == false)
            {
                if (_checkingForRange.InRange(_enemy.transform.position))
                {
                    if (_isReloaded)
                    {
                        EnterAttackMode();
                        return;
                    }
                    ExitAttackMode();
                    return;
                }
                ExitAttackModeWithAnimation();
                return;
            }
            ExitAttackModeWithAnimation();
        }

        private void EnterAttackMode()
        {
            IsAttacking = true;
            _attackingAnimator.StartAttack();
        }

        private void ExitAttackMode()
        {
            IsAttacking = false;
            _attackingAnimator.StopAttack();
        }

        private void ExitAttackModeWithAnimation()
        {
            IsAttacking = false;
            _attackingAnimator.StopAttackImmediately();
        }

        private void AttackHittedEnemy()
        {
            if (_enemy != null)
            {
                _attacking.Attack(_enemy);
                _timeSinceLastAttack = 0f;
            }
        }
    }
}